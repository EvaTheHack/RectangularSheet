using RectangularSheet.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RectangularSheet.WF
{
    public class DetailDrawer
    {
        private int Width { get; set; }
        private int Height { get; set; }

        private readonly Graphics _graphics;
        private readonly Panel _panel;
        private readonly SolidBrush _brush = new(Color.Red);
        private readonly int _detailsCounts;
        private readonly int[,] _sheet;

        private const float BORDER = 1f;

        private int detailsPlaced = 0;

        public DetailDrawer(Panel panel, int sheetWidth, int sheetHeight, List<Detail> details)
        {
            _panel = panel;
            _graphics = panel.CreateGraphics();
            _detailsCounts = details.Sum(x => x.Count);
            _sheet = new int[sheetHeight, sheetWidth];

            Width = sheetWidth;
            Height = sheetHeight;
            ValidateFilling(details);
        }

        private float Offset => (float)(_panel.Height - 1) / (float)MaxSide;

        private int MaxSide => Height > Width ? Height : Width;

        public void Draw(List<Detail> details)
        {
            foreach (var d in details)
            {
                for (int i = 0; i < d.Count; i++)
                {
                    DrawDetail(d.Width, d.Height);
                }
            }
        }

        /// <summary>
        /// Draw detail in panel
        /// </summary>
        private void DrawDetail(int detailWidth, int detailHeight)
        {
            for (int i = 0; i < Height; i++)
            {
                var hasEmptyValueInRow = CheckIfRowHasEnoughWidth(i, _sheet, detailWidth);
                if (!hasEmptyValueInRow)
                {
                    continue;
                }
                for (int j = 0; j < Width; j++)
                {
                    if (_sheet[i, j] != 0)
                    {
                        continue;
                    }

                    if (detailsPlaced == _detailsCounts)
                    {
                        return;
                    }

                    if (IsSquareFreeHorizontally(i, j, _sheet, detailWidth, detailHeight))
                    {
                        FillHorizontally(i, j, _sheet, detailWidth, detailHeight);
                        var cords = CalculareCords(i, j, detailWidth, detailHeight);
                        _graphics.FillRectangle(_brush, new RectangleF(cords.Item1, cords.Item2, cords.Item3, cords.Item4));
                        detailsPlaced++;
                        return;
                    }

                    if (IsSquareFreeVertically(i, j, _sheet, detailWidth, detailHeight))
                    {
                        FillVertically(i, j, _sheet, detailWidth, detailHeight);
                        var cords = CalculareCords(i, j, detailWidth, detailHeight);
                        _graphics.FillRectangle(_brush, new RectangleF(cords.Item1, cords.Item2, cords.Item4, cords.Item3));
                        detailsPlaced++;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Check if vertically square for details is free
        /// </summary>
        private bool IsSquareFreeVertically(int x, int y, int[,] sheet, int detailWidth, int detailHeight)
        {
            var maxWidth = x + detailWidth;
            var maxHeight = y + detailHeight;
            try
            {
                for (int i = x; i < maxWidth; i++)
                {
                    for (int j = y; j < maxHeight; j++)
                    {
                        if(sheet[i, j] != 0)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check if horizontally square for details is free
        /// </summary>
        private bool IsSquareFreeHorizontally(int x, int y, int[,] sheet, int detailWidth, int detailHeight)
        {
            var maxWidth = y + detailWidth;
            var maxHeight = x + detailHeight;
            try
            {
                for (int i = x; i < maxHeight; i++)
                {
                    for (int j = y; j < maxWidth; j++)
                    {
                        if (sheet[i, j] != 0)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Fill array horizontally for further drawing by coordinates 
        /// </summary>
        private void FillHorizontally(int x, int y, int[,] sheet, int detailWidth, int detailHeight)
        {
            for (int i = x; i < x + detailHeight; i++)
            {
                for (int j = y; j < y + detailWidth; j++)
                {
                    sheet[i, j] = 1;
                }
            }
        }

        /// <summary>
        /// Fill array vertically for further drawing by coordinates 
        /// </summary>
        private void FillVertically(int x, int y, int[,] sheet, int detailWidth, int detailHeight)
        {
            for (int i = x; i < x + detailWidth; i++)
            {
                for (int j = y; j < y + detailHeight; j++)
                {
                    sheet[i, j] = 1;
                }
            }
        }

        /// <summary>
        /// Method calculate co0rdinates for drawing rectangle
        /// </summary>
        /// <returns>Item1 - x, Item2 - y, Item3 - width, Item4 - height</returns>
        private Tuple<float, float, float, float> CalculareCords(int x, int y, int detailWidth, int detailHeight)
        {
            return Tuple.Create(
                        y * Offset + BORDER,
                        x * Offset + BORDER,
                        (float)detailWidth * Offset - BORDER,
                        (float)detailHeight * Offset - BORDER
                    );
        }

        /// <summary>
        /// Method allow validate filling of details
        /// </summary>
        private void ValidateFilling(List<Detail> details)
        {
            var tempSheet = new int[Height, Width];
            var tempDetails = 0;
            foreach (var d in details)
            {
                for (int i = 0; i < d.Count; i++)
                {
                    Fill(ref tempDetails, ref tempSheet, d.Width, d.Height, d.Count);
                }
            }

            if (_detailsCounts > tempDetails)
            {
                throw new Exception($"Невозможно разместить такое кол-во деталей - {_detailsCounts}");
            }

            return;
        }

        /// <summary>
        /// Fill temporary array
        /// </summary>
        private void Fill(ref int tempDetails, ref int[,] tempSheet, int detailWidth, int detailHeight, int count)
        {
            for (int i = 0; i < Height; i++)
            {
                var hasEmptyValueInRow = CheckIfRowHasEnoughWidth(i, tempSheet, detailWidth);
                if(!hasEmptyValueInRow)
                {
                    continue;
                }
                for (int j = 0; j < Width; j++)
                {
                    if (tempSheet[i, j] != 0)
                    {
                        continue;
                    }

                    if (tempDetails == _detailsCounts)
                    {
                        return;
                    }

                    if (IsSquareFreeHorizontally(i, j, tempSheet, detailWidth, detailHeight))
                    {
                        FillHorizontally(i, j, tempSheet, detailWidth, detailHeight);
                        tempDetails++;
                        return;
                    }

                    if (IsSquareFreeVertically(i, j, tempSheet, detailWidth, detailHeight))
                    {
                        FillVertically(i, j, tempSheet, detailWidth, detailHeight);
                        tempDetails++;
                        return;
                    }
                }
            }
        }

        private bool CheckIfRowHasEnoughWidth(int i, int[,] tempSheet, int detailWidth)
        {
            var row = Enumerable.Range(0, tempSheet.GetLength(1)).Select(x => tempSheet[i, x]);

            return row.Count(x => x == 0) >= detailWidth;
        }
    }
}

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

        public void Draw(int detailWidth, int detailHeight)
        {
            for (int i = 0; i < Height; i++)
            {
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

        private bool IsSquareFreeVertically(int x, int y, int[,] sheet, int detailWidth, int detailHeight)
        {
            try
            {
                return sheet[x, y] == 0 &&
                       sheet[x, y + detailHeight - 1] == 0 &&
                       sheet[x + detailWidth - 1, y] == 0 &&
                       sheet[x + detailWidth - 1, y + detailHeight - 1] == 0;
            }
            catch
            {
                return false;
            }
        }

        private bool IsSquareFreeHorizontally(int x, int y, int[,] sheet, int detailWidth, int detailHeight)
        {
            try
            {
                return sheet[x, y] == 0 &&
                       sheet[x, y + detailWidth - 1] == 0 &&
                       sheet[x + detailHeight - 1, y] == 0 &&
                       sheet[x + detailHeight - 1, y + detailWidth - 1] == 0;
            }
            catch
            {
                return false;
            }
        }

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

        private void ValidateFilling(List<Detail> details)
        {
            var tempSheet = new int[Height, Width];
            var tempDetails = 0;
            foreach (var d in details)
            {
                for (int i = 0; i < d.Count; i++)
                {
                    Fill(ref tempDetails, tempSheet, d.Width, d.Height);
                }
            }

            if (_detailsCounts > tempDetails)
            {
                throw new Exception($"Невозможно разместить такое кол-во деталей - {_detailsCounts}");
            }

            return;
        }

        private void Fill(ref int tempDetails, int[,] tempSheet, int detailWidth, int detailHeight)
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (_sheet[i, j] != 0)
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
                        break;
                    }

                    if (IsSquareFreeVertically(i, j, tempSheet, detailWidth, detailHeight))
                    {
                        FillVertically(i, j, tempSheet, detailWidth, detailHeight);
                        tempDetails++;
                        break;
                    }
                }
            }
        }
    }
}

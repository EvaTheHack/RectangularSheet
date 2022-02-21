using System;
using System.Drawing;
using System.Windows.Forms;

namespace RectangularSheet.WF
{
    public class DetailDrawer
    {
        private readonly Graphics graphics;
        private readonly Panel _panel;
        private readonly SolidBrush brush = new(Color.Red);
        private readonly int _detailHeight;
        private readonly int _detailWidth;
        private readonly int _detailsCounts;
        private readonly int[,] _sheet;

        private const float BORDER = 1f;

        private int detailsPlaced = 0;

        public DetailDrawer(Panel panel, int sheetWidth, int sheetHeight, int detailHeight, int detailWidth, int detailsCounts)
        {
            _panel = panel;
            graphics = panel.CreateGraphics();
            Width = sheetWidth;
            Height = sheetHeight;

            _detailHeight = detailHeight;
            _detailWidth = detailWidth;
            _detailsCounts = detailsCounts;
            _sheet = new int[sheetHeight, sheetWidth];
        }

        private int Width { get; set; }

        private int Height { get; set; }

        private float Offset => (float)(_panel.Height - 1) / (float)MaxSide;

        private int MaxSide => Height > Width ? Height : Width;

        public void Draw()
        {
            ValidateFilling();

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

                    if (IsSquareFreeHorizontally(i, j, _sheet))
                    {
                        FillHorizontally(i, j, _sheet);
                        var cords = CalculareCords(i, j);
                        graphics.FillRectangle(brush, new RectangleF(cords.Item1, cords.Item2, cords.Item3, cords.Item4));
                        detailsPlaced++;
                        continue;
                    }

                    if (IsSquareFreeVertically(i, j, _sheet))
                    {
                        FillVertically(i, j, _sheet);
                        var cords = CalculareCords(i, j);
                        graphics.FillRectangle(brush, new RectangleF(cords.Item1, cords.Item2, cords.Item4, cords.Item3));
                        detailsPlaced++;
                    }
                }
            }
        }

        private bool IsSquareFreeVertically(int x, int y, int[,] sheet)
        {
            try
            {
                return sheet[x, y] == 0 &&
                       sheet[x, y + _detailHeight - 1] == 0 &&
                       sheet[x + _detailWidth - 1, y] == 0 &&
                       sheet[x + _detailWidth - 1, y + _detailHeight - 1] == 0;
            }
            catch
            {
                return false;
            }
        }

        private bool IsSquareFreeHorizontally(int x, int y, int[,] sheet)
        {
            try
            {
                return sheet[x, y] == 0 &&
                       sheet[x, y + _detailWidth - 1] == 0 &&
                       sheet[x + _detailHeight - 1, y] == 0 &&
                       sheet[x + _detailHeight - 1, y + _detailWidth - 1] == 0;
            }
            catch
            {
                return false;
            }
        }

        private void FillHorizontally(int x, int y, int[,] sheet)
        {
            for (int i = x; i < x + _detailHeight; i++)
            {
                for (int j = y; j < y + _detailWidth; j++)
                {
                    sheet[i, j] = 1;
                }
            }
        }

        private void FillVertically(int x, int y, int[,] sheet)
        {
            for (int i = x; i < x + _detailWidth; i++)
            {
                for (int j = y; j < y + _detailHeight; j++)
                {
                    sheet[i, j] = 1;
                }
            }
        }

        /// <summary>
        /// Method calculate co0rdinates for drawing rectangle
        /// </summary>
        /// <returns>Item1 - x, Item2 - y, Item3 - width, Item4 - height</returns>
        private Tuple<float, float, float, float> CalculareCords(int x, int y)
        {
            return Tuple.Create(
                        y * Offset + BORDER,
                        x * Offset + BORDER,
                        (float)_detailWidth * Offset - BORDER,
                        (float)_detailHeight * Offset - BORDER
                    );
        }

        private void ValidateFilling()
        {
            var tempSheet = new int[Height, Width];
            var tempDetails = 0;
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

                    if (IsSquareFreeHorizontally(i, j, tempSheet))
                    {
                        FillHorizontally(i, j, tempSheet);
                        tempDetails++;
                        continue;
                    }

                    if (IsSquareFreeVertically(i, j, tempSheet))
                    {
                        FillVertically(i, j, tempSheet);
                        tempDetails++;
                    }
                }
            }

            if (_detailsCounts > tempDetails)
            {
                throw new Exception($"Невозможно разместить такое кол-во деталей - {_detailsCounts}");
            }

            return;
        }
    }
}

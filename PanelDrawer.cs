using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RectangularSheet.WF
{
    public class PanelDrawer
    {
        private Graphics graphics;
        private Pen pen = new(Brushes.Black, 1);
        private Panel panel;

        public PanelDrawer(Panel panel, int width, int height)
        {
            this.panel = panel;
            graphics = panel.CreateGraphics();
            graphics.Clear(Color.White);
            Width = width;
            Height = height;
        }

        public int Width { get; private set; }
        
        public int Height { get; private set; }
        
        public int Diff => Math.Abs(Width - Height);

        public float Offset => (float)(panel.Height - 1) / (float)MaxSide;
        
        public int MaxSide => Height > Width ? Height : Width;

        public float HorizontalOffset => Height < Width ? Offset : 0;

        public float VerticalOffset =>   Height > Width ? Offset : 0;

        public void DrawPerimeter()
        {
            DrawHorizontalLines();
            DrawVerticalLines();
        }

        private void DrawHorizontalLines()
        {
            var x = 0f;
            var y = 0f;

            for (int i = 0; i < Width + 1; i++)
            {
                if (i == 0 || i == Width)
                {
                    graphics.DrawLine(pen, x, y, x, panel.Height - Diff * HorizontalOffset - 1);
                }
                x += Offset;
            }
        }

        private void DrawVerticalLines()
        {
            var x = 0f;
            var y = 0f;

            for (int i = 0; i < Height + 1; i++)
            {
                if (i == 0 || i == Height)
                {
                    graphics.DrawLine(pen, x, y, panel.Height - Diff * VerticalOffset - 1, y);
                }
                y += Offset;
            }
        }
    }
}

using RectangularSheet.Models;
using RectangularSheet.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace RectangularSheet.WF
{
    public partial class Form1 : Form
    {
        private readonly List<DetailDto> _details = new();
        public Form1()
        {
            InitializeComponent();
            var bindingList = new BindingList<DetailDto>(_details);
            var source = new BindingSource(bindingList, null);
            gridDetails.DataSource = source;
        }

        private void ButtonDraw_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrEmpty(textBoxWidthSheet.Text) ||
                string.IsNullOrEmpty(textBoxHeightSheet.Text)
                )
            {
                MessageBox.Show("Неверно указаны размеры");
                return;
            }
            var width = Convert.ToInt32(textBoxWidthSheet.Text);
            var height = Convert.ToInt32(textBoxHeightSheet.Text);

            var details = _details.Map();

            var panelDrawer = new PanelDrawer(panelSheet, width, height);
            var detailDrawer = new DetailDrawer(panelSheet, width, height, details);

            try
            {
                detailDrawer.Draw(details);        
                panelDrawer.DrawPerimeter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonRemoveRow_Click(object sender, EventArgs e)
        {
            try
            {
                if(gridDetails.Rows.Count == 1)
                {
                    throw new Exception("Нельзя удалить единственную строку");
                }
                if (gridDetails.CurrentCell == null)
                {
                    throw new Exception("Не выбрана строка");
                }
                var index = gridDetails.CurrentCell.RowIndex;
                gridDetails.Rows.RemoveAt(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBoxWidthSheet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TextBoxHeightSheet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void GridDetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Column_KeyPress);
        }

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

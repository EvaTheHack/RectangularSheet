using System;
using System.Windows.Forms;

namespace RectangularSheet.WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBoxWidthSheet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxHeightSheet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxWidthDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxHeightDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxCountDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void buttonDarw_Click(object sender, EventArgs e)
        {
            if (
                textBoxWidthSheet.Text.Length   < 1 ||
                textBoxHeightSheet.Text.Length  < 1 ||
                textBoxWidthDetail.Text.Length  < 1 ||
                textBoxHeightDetail.Text.Length < 1
                )
            {
                MessageBox.Show("Неверно указаны размеры");
                return;
            }
            var width = Convert.ToInt32(textBoxWidthSheet.Text);
            var height = Convert.ToInt32(textBoxHeightSheet.Text);
            var detailWidth = Convert.ToInt32(textBoxWidthDetail.Text);
            var detailHeight = Convert.ToInt32(textBoxHeightDetail.Text);
            var detailCount = Convert.ToInt32(textBoxCountDetails.Text);
            
            var panelDrawer = new PanelDrawer(panelSheet, width, height);
            var detailDrawer = new DetailDrawer(panelSheet, width, height, detailHeight, detailWidth, detailCount);

            try
            {
                detailDrawer.Draw();
                panelDrawer.DrawPerimeter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

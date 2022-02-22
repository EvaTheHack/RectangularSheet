
namespace RectangularSheet.WF
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxSheet = new System.Windows.Forms.GroupBox();
            this.textBoxHeightSheet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxWidthSheet = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.buttonRemoveRow = new System.Windows.Forms.Button();
            this.gridDetails = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.panelSheet = new System.Windows.Forms.Panel();
            this.groupBoxSheet.SuspendLayout();
            this.groupBoxDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxSheet
            // 
            this.groupBoxSheet.Controls.Add(this.textBoxHeightSheet);
            this.groupBoxSheet.Controls.Add(this.label2);
            this.groupBoxSheet.Controls.Add(this.textBoxWidthSheet);
            this.groupBoxSheet.Controls.Add(this.label1);
            this.groupBoxSheet.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSheet.Name = "groupBoxSheet";
            this.groupBoxSheet.Size = new System.Drawing.Size(288, 118);
            this.groupBoxSheet.TabIndex = 0;
            this.groupBoxSheet.TabStop = false;
            this.groupBoxSheet.Text = "Лист";
            // 
            // textBoxHeightSheet
            // 
            this.textBoxHeightSheet.Location = new System.Drawing.Point(157, 74);
            this.textBoxHeightSheet.Name = "textBoxHeightSheet";
            this.textBoxHeightSheet.Size = new System.Drawing.Size(125, 27);
            this.textBoxHeightSheet.TabIndex = 3;
            this.textBoxHeightSheet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHeightSheet_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Высота";
            // 
            // textBoxWidthSheet
            // 
            this.textBoxWidthSheet.Location = new System.Drawing.Point(157, 41);
            this.textBoxWidthSheet.Name = "textBoxWidthSheet";
            this.textBoxWidthSheet.Size = new System.Drawing.Size(125, 27);
            this.textBoxWidthSheet.TabIndex = 1;
            this.textBoxWidthSheet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxWidthSheet_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ширина";
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.buttonRemoveRow);
            this.groupBoxDetails.Controls.Add(this.gridDetails);
            this.groupBoxDetails.Location = new System.Drawing.Point(12, 146);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(288, 256);
            this.groupBoxDetails.TabIndex = 7;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Детали";
            // 
            // buttonRemoveRow
            // 
            this.buttonRemoveRow.Location = new System.Drawing.Point(72, 205);
            this.buttonRemoveRow.Name = "buttonRemoveRow";
            this.buttonRemoveRow.Size = new System.Drawing.Size(113, 29);
            this.buttonRemoveRow.TabIndex = 9;
            this.buttonRemoveRow.Text = "Удалить";
            this.buttonRemoveRow.UseVisualStyleBackColor = true;
            this.buttonRemoveRow.Click += new System.EventHandler(this.buttonRemoveRow_Click);
            // 
            // gridDetails
            // 
            this.gridDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetails.Location = new System.Drawing.Point(11, 27);
            this.gridDetails.Name = "gridDetails";
            this.gridDetails.RowHeadersVisible = false;
            this.gridDetails.RowHeadersWidth = 51;
            this.gridDetails.RowTemplate.Height = 29;
            this.gridDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridDetails.Size = new System.Drawing.Size(271, 172);
            this.gridDetails.TabIndex = 0;
            this.gridDetails.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridDetails_EditingControlShowing);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(84, 408);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 29);
            this.button2.TabIndex = 6;
            this.button2.Text = "Расчет";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonDarw_Click);
            // 
            // panelSheet
            // 
            this.panelSheet.AutoScroll = true;
            this.panelSheet.AutoSize = true;
            this.panelSheet.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panelSheet.Location = new System.Drawing.Point(326, 23);
            this.panelSheet.Name = "panelSheet";
            this.panelSheet.Padding = new System.Windows.Forms.Padding(10);
            this.panelSheet.Size = new System.Drawing.Size(526, 526);
            this.panelSheet.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 583);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panelSheet);
            this.Controls.Add(this.groupBoxDetails);
            this.Controls.Add(this.groupBoxSheet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RectangularSheet";
            this.groupBoxSheet.ResumeLayout(false);
            this.groupBoxSheet.PerformLayout();
            this.groupBoxDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSheet;
        private System.Windows.Forms.TextBox textBoxHeightSheet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxWidthSheet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelSheet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonGrid;
        private System.Windows.Forms.DataGridView gridDetails;
        private System.Windows.Forms.Button buttonRemoveRow;
    }
}


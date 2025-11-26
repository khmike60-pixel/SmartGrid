
namespace SmartGrid
{
    partial class SumForm
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
            this.SumTB = new C1.Win.Input.C1TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SumTB)).BeginInit();
            this.SuspendLayout();
            // 
            // SumTB
            // 
            this.SumTB.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SumTB.Location = new System.Drawing.Point(12, 12);
            this.SumTB.Name = "SumTB";
            this.SumTB.ReadOnly = true;
            this.SumTB.Size = new System.Drawing.Size(150, 20);
            this.SumTB.TabIndex = 0;
            this.SumTB.TabStop = false;
            this.SumTB.Tag = null;
            this.SumTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 44);
            this.Controls.Add(this.SumTB);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "SumForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Сумма";
            ((System.ComponentModel.ISupportInitialize)(this.SumTB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.Input.C1TextBox SumTB;
    }
}

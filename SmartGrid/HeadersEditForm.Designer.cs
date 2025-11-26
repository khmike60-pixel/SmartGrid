namespace SmartGrid
{
    partial class HeadersEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeadersEditForm));
            this.ButtonOk = new C1.Win.Input.C1Button();
            this.ButtonCancel = new C1.Win.Input.C1Button();
            this.headersGrid = new HeadersEditor();
            this.ButtonMerge = new C1.Win.Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headersGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMerge)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonOk
            // 
            this.ButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOk.Location = new System.Drawing.Point(694, 177);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 1;
            this.ButtonOk.Text = "OK";
            //this.ButtonOk.UseVisualStyleBackColor = true;
            //this.ButtonOk.UseVisualStyleForeColor = true;
            //this.ButtonOk.VisualStyle = C1.Win.Input.VisualStyle.Office2010Silver;
            //this.ButtonOk.VisualStyleBaseStyle = C1.Win.Input.VisualStyle.Office2010Silver;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.Location = new System.Drawing.Point(782, 177);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "Cancel";
            //this.ButtonCancel.UseVisualStyleBackColor = true;
            //this.ButtonCancel.UseVisualStyleForeColor = true;
            //this.ButtonCancel.VisualStyle = C1.Win.Input.VisualStyle.Office2010Silver;
            //this.ButtonCancel.VisualStyleBaseStyle = C1.Win.Input.VisualStyle.Office2010Silver;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // headersGrid
            // 
            this.headersGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headersGrid.AutoClipboard = true;
            this.headersGrid.AutoResize = true;
            this.headersGrid.BackColor = System.Drawing.SystemColors.Control;
            this.headersGrid.ColumnInfo = "10,0,0,0,0,-1,Columns:";
            this.headersGrid.ForeColor = System.Drawing.SystemColors.ControlText;
            this.headersGrid.Headers = null;
            this.headersGrid.Location = new System.Drawing.Point(0, 0);
            this.headersGrid.Name = "headersGrid";
            this.headersGrid.Rows.Count = 10;
            this.headersGrid.Rows.Fixed = 0;
            this.headersGrid.Size = new System.Drawing.Size(878, 165);
            this.headersGrid.StyleInfo = resources.GetString("headersGrid.StyleInfo");
            this.headersGrid.TabIndex = 3;
            // 
            // ButtonMerge
            // 
            this.ButtonMerge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonMerge.Location = new System.Drawing.Point(23, 177);
            this.ButtonMerge.Name = "ButtonMerge";
            this.ButtonMerge.Size = new System.Drawing.Size(87, 23);
            this.ButtonMerge.TabIndex = 4;
            this.ButtonMerge.Text = "Merge preview";
            //this.ButtonMerge.UseVisualStyleBackColor = true;
            //this.ButtonMerge.UseVisualStyleForeColor = true;
            //this.ButtonMerge.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            //this.ButtonMerge.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.ButtonMerge.Click += new System.EventHandler(this.ButtonMerge_Click);
            // 
            // HeadersEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 211);
            this.Controls.Add(this.ButtonMerge);
            this.Controls.Add(this.headersGrid);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.Name = "HeadersEditForm";
            this.Text = "Headers Editor";
            ((System.ComponentModel.ISupportInitialize)(this.ButtonOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headersGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMerge)).EndInit();
            this.ResumeLayout(false);
        }
        private C1.Win.Input.C1Button ButtonOk;
        private C1.Win.Input.C1Button ButtonCancel;
        private HeadersEditor headersGrid;
        private C1.Win.Input.C1Button ButtonMerge;

        #endregion
    }
}
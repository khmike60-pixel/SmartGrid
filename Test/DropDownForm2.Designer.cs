namespace Test
{
    partial class DropDownForm2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DropDownForm2));
            this.Grid = new SmartGrid.SmartGrid();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.ColumnInfo = "10,1,0,0,0,-1,Columns:0{Width:30;}\t";
            this.Grid.Headers = null;
            this.Grid.IsEditing = false;
            this.Grid.Location = new System.Drawing.Point(13, 13);
            this.Grid.Name = "Grid";
            this.Grid.Rows.Count = 10;
            this.Grid.SelectedRows = ((System.Collections.Generic.List<int>)(resources.GetObject("Grid.SelectedRows")));
            this.Grid.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            this.Grid.Size = new System.Drawing.Size(521, 221);
            this.Grid.StyleInfo = resources.GetString("Grid.StyleInfo");
            this.Grid.TabIndex = 0;
            // 
            // DropDownForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 250);
            this.Controls.Add(this.Grid);
            this.Name = "DropDownForm2";
            this.Text = "DropDownForm2";
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SmartGrid.SmartGrid Grid;
    }
}
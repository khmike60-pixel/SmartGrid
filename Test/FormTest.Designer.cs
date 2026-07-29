namespace Test
{
    partial class FormTest
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest));
            c1SuperTooltip1 = new C1.Win.SuperTooltip.C1SuperTooltip(components);
            buttonRefresh = new Button();
            c1SplitContainer1 = new C1.Win.SplitContainer.C1SplitContainer();
            c1SplitterPanel1 = new C1.Win.SplitContainer.C1SplitterPanel();
            c1NumericEdit1 = new C1.Win.Input.C1NumericEdit();
            c1SplitterPanel2 = new C1.Win.SplitContainer.C1SplitterPanel();
            Grid3 = new SmartGrid.SmartGrid();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).BeginInit();
            c1SplitContainer1.SuspendLayout();
            c1SplitterPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c1NumericEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Grid3).BeginInit();
            SuspendLayout();
            // 
            // c1SuperTooltip1
            // 
            c1SuperTooltip1.Font = new Font("Tahoma", 8F);
            c1SuperTooltip1.RightToLeft = RightToLeft.Inherit;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonRefresh.Location = new Point(794, 298);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(75, 23);
            buttonRefresh.TabIndex = 3;
            buttonRefresh.Text = "Refresh";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // c1SplitContainer1
            // 
            c1SplitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            c1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            c1SplitContainer1.HeaderButtonBackColor = Color.Transparent;
            c1SplitContainer1.Location = new Point(12, 12);
            c1SplitContainer1.Name = "c1SplitContainer1";
            c1SplitContainer1.Panels.Add(c1SplitterPanel1);
            c1SplitContainer1.Panels.Add(c1SplitterPanel2);
            c1SplitContainer1.Size = new Size(401, 280);
            c1SplitContainer1.TabIndex = 4;
            // 
            // c1SplitterPanel1
            // 
            c1SplitterPanel1.Controls.Add(c1NumericEdit1);
            c1SplitterPanel1.Height = 138;
            c1SplitterPanel1.Location = new Point(0, 21);
            c1SplitterPanel1.Name = "c1SplitterPanel1";
            c1SplitterPanel1.Size = new Size(401, 117);
            c1SplitterPanel1.TabIndex = 0;
            c1SplitterPanel1.Text = "Panel 1";
            // 
            // c1NumericEdit1
            // 
            c1NumericEdit1.Location = new Point(91, 30);
            c1NumericEdit1.Name = "c1NumericEdit1";
            c1NumericEdit1.Size = new Size(100, 23);
            c1NumericEdit1.TabIndex = 0;
            c1NumericEdit1.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // c1SplitterPanel2
            // 
            c1SplitterPanel2.Height = 138;
            c1SplitterPanel2.Location = new Point(0, 163);
            c1SplitterPanel2.Name = "c1SplitterPanel2";
            c1SplitterPanel2.Size = new Size(401, 117);
            c1SplitterPanel2.TabIndex = 1;
            c1SplitterPanel2.Text = "Panel 2";
            // 
            // Grid3
            // 
            Grid3.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.None;
            Grid3.AllowNodeMove = false;
            Grid3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Grid3.ColumnInfo = "10,1,0,0,0,-1,Columns:0{Width:30;}\t";
            Grid3.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            Grid3.Headers = null;
            Grid3.IdName = null;
            Grid3.IsEditing = false;
            Grid3.Location = new Point(419, 12);
            Grid3.Name = "Grid3";
            Grid3.Rows.Count = 10;
            Grid3.Rows.Fixed = 2;
            Grid3.SelectedRows = null;
            Grid3.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            Grid3.Size = new Size(450, 280);
            Grid3.SortingType = SmartGrid.SortingType.Descending;
            Grid3.StyleInfo = resources.GetString("Grid3.StyleInfo");
            Grid3.TabIndex = 5;
            Grid3.Tree.Column = 2;
            Grid3.ValidateDragTarget += Grid3_ValidateDragTarget;
            // 
            // FormTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 333);
            Controls.Add(Grid3);
            Controls.Add(c1SplitContainer1);
            Controls.Add(buttonRefresh);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormTest";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).EndInit();
            c1SplitContainer1.ResumeLayout(false);
            c1SplitterPanel1.ResumeLayout(false);
            c1SplitterPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)c1NumericEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Grid3).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private C1.Win.SuperTooltip.C1SuperTooltip c1SuperTooltip1;
        private SmartGrid.SmartGrid Grid3;
        private Button buttonRefresh;
        private C1.Win.SplitContainer.C1SplitContainer c1SplitContainer1;
        private C1.Win.SplitContainer.C1SplitterPanel c1SplitterPanel1;
        private C1.Win.SplitContainer.C1SplitterPanel c1SplitterPanel2;
        private SmartGrid.SmartGrid smartGrid1;
        private C1.Win.Input.C1NumericEdit c1NumericEdit1;
    }
}
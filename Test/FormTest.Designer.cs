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
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.FooterDescription footerDescription2 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition2 = new C1.Win.FlexGrid.AggregateDefinition();
            c1SuperTooltip1 = new C1.Win.SuperTooltip.C1SuperTooltip(components);
            Grid3 = new SmartGrid.SmartGrid();
            buttonRefresh = new Button();
            c1SplitContainer1 = new C1.Win.SplitContainer.C1SplitContainer();
            c1SplitterPanel1 = new C1.Win.SplitContainer.C1SplitterPanel();
            c1NumericEdit1 = new C1.Win.Input.C1NumericEdit();
            c1SplitterPanel2 = new C1.Win.SplitContainer.C1SplitterPanel();
            smartGrid1 = new SmartGrid.SmartGrid();
            ((System.ComponentModel.ISupportInitialize)Grid3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).BeginInit();
            c1SplitContainer1.SuspendLayout();
            c1SplitterPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c1NumericEdit1).BeginInit();
            c1SplitterPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smartGrid1).BeginInit();
            SuspendLayout();
            // 
            // c1SuperTooltip1
            // 
            c1SuperTooltip1.Font = new Font("Tahoma", 8F);
            c1SuperTooltip1.RightToLeft = RightToLeft.Inherit;
            // 
            // Grid3
            // 
            Grid3.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            Grid3.AllowNodeMove = true;
            Grid3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Grid3.ColumnInfo = resources.GetString("Grid3.ColumnInfo");
            Grid3.Dock = DockStyle.Fill;
            Grid3.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 1;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            Grid3.Footers.Descriptions.Add(footerDescription1);
            Grid3.Footers.Fixed = true;
            Grid3.Headers = new string[]
    {
    "0\tСубколонка 1\tСубколонка 1\tСубколонка 1\t4\t4\t6\t6\t8\t9",
    "0\tКолонка 1\tКолонка 2\tКолонка 3\tКолонка 4\tКолонка 5\tКолонка 6\t7\t8\t9"
    };
            Grid3.IdName = null;
            Grid3.IsEditing = false;
            Grid3.Location = new Point(0, 0);
            Grid3.Margin = new Padding(4, 3, 4, 3);
            Grid3.Name = "Grid3";
            Grid3.Rows.Count = 12;
            Grid3.SelectedRows = null;
            Grid3.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            Grid3.Size = new Size(401, 185);
            Grid3.SortingType = SmartGrid.SortingType.Descending;
            Grid3.StyleInfo = resources.GetString("Grid3.StyleInfo");
            Grid3.TabIndex = 2;
            Grid3.UseCompatibleTextRendering = true;
            Grid3.ValidateDragTarget += Grid3_ValidateDragTarget;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonRefresh.Location = new Point(699, 434);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(75, 23);
            buttonRefresh.TabIndex = 3;
            buttonRefresh.Text = "Refresh";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // c1SplitContainer1
            // 
            c1SplitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            c1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            c1SplitContainer1.HeaderButtonBackColor = Color.Transparent;
            c1SplitContainer1.Location = new Point(12, 12);
            c1SplitContainer1.Name = "c1SplitContainer1";
            c1SplitContainer1.Panels.Add(c1SplitterPanel1);
            c1SplitContainer1.Panels.Add(c1SplitterPanel2);
            c1SplitContainer1.Size = new Size(401, 416);
            c1SplitContainer1.TabIndex = 4;
            // 
            // c1SplitterPanel1
            // 
            c1SplitterPanel1.Controls.Add(c1NumericEdit1);
            c1SplitterPanel1.Height = 206;
            c1SplitterPanel1.Location = new Point(0, 21);
            c1SplitterPanel1.Name = "c1SplitterPanel1";
            c1SplitterPanel1.Size = new Size(401, 185);
            c1SplitterPanel1.TabIndex = 0;
            c1SplitterPanel1.Text = "Panel 1";
            // 
            // c1NumericEdit1
            // 
            c1NumericEdit1.Location = new Point(104, 98);
            c1NumericEdit1.Name = "c1NumericEdit1";
            c1NumericEdit1.Size = new Size(100, 23);
            c1NumericEdit1.TabIndex = 0;
            c1NumericEdit1.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // c1SplitterPanel2
            // 
            c1SplitterPanel2.Controls.Add(Grid3);
            c1SplitterPanel2.Height = 206;
            c1SplitterPanel2.Location = new Point(0, 231);
            c1SplitterPanel2.Name = "c1SplitterPanel2";
            c1SplitterPanel2.Size = new Size(401, 185);
            c1SplitterPanel2.TabIndex = 1;
            c1SplitterPanel2.Text = "Panel 2";
            // 
            // smartGrid1
            // 
            smartGrid1.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGrid1.AllowNodeMove = true;
            smartGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            smartGrid1.ColumnInfo = resources.GetString("smartGrid1.ColumnInfo");
            smartGrid1.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition2.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition2.Caption = "Всего: ";
            aggregateDefinition2.Column = 1;
            footerDescription2.Aggregates.Add(aggregateDefinition2);
            smartGrid1.Footers.Descriptions.Add(footerDescription2);
            smartGrid1.Footers.Fixed = true;
            smartGrid1.Headers = new string[]
    {
    "0\tСубколонка 1\tСубколонка 1\tСубколонка 1\t4\t4\t6\t6\t8\t9",
    "10\tКолонка 1\tКолонка 2\tКолонка 3\tКолонка 4\tКолонка 5\tКолонка 6\t7\t8\t9"
    };
            smartGrid1.IdName = null;
            smartGrid1.IsEditing = false;
            smartGrid1.Location = new Point(420, 12);
            smartGrid1.Name = "smartGrid1";
            smartGrid1.Rows.Count = 12;
            smartGrid1.SelectedRows = (List<int>)resources.GetObject("smartGrid1.SelectedRows");
            smartGrid1.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGrid1.Size = new Size(354, 416);
            smartGrid1.SortingType = SmartGrid.SortingType.Descending;
            smartGrid1.StyleInfo = resources.GetString("smartGrid1.StyleInfo");
            smartGrid1.TabIndex = 5;
            // 
            // Form2
            // 
            // FormTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(786, 469);
            Controls.Add(smartGrid1);
            Controls.Add(c1SplitContainer1);
            Controls.Add(buttonRefresh);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormTest";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)Grid3).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).EndInit();
            c1SplitContainer1.ResumeLayout(false);
            c1SplitterPanel1.ResumeLayout(false);
            c1SplitterPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)c1NumericEdit1).EndInit();
            c1SplitterPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)smartGrid1).EndInit();
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
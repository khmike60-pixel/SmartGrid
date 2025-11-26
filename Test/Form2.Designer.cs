namespace Test
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition2 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition3 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition4 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.FooterDescription footerDescription2 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition5 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition6 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition7 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.FooterDescription footerDescription3 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition8 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition9 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition10 = new C1.Win.FlexGrid.AggregateDefinition();
            c1SuperTooltip1 = new C1.Win.SuperTooltip.C1SuperTooltip(components);
            Grid3 = new SmartGrid.SmartGrid();
            Grid2 = new SmartGrid.SmartGrid();
            Grid = new SmartGrid.SmartGrid();
            ((System.ComponentModel.ISupportInitialize)Grid3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Grid2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Grid).BeginInit();
            SuspendLayout();
            // 
            // c1SuperTooltip1
            // 
            c1SuperTooltip1.Font = new Font("Tahoma", 8F);
            c1SuperTooltip1.RightToLeft = RightToLeft.Inherit;
            // 
            // Grid3
            // 
            Grid3.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.None;
            Grid3.AllowNodeMove = true;
            Grid3.ColumnInfo = "10,1,0,0,0,-1,Columns:0{Width:30;}\t1{Name:\"Name\";}\t2{Name:\"Id\";}\t3{Name:\"ParentId\";}\t";
            Grid3.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            Grid3.Headers = null;
            Grid3.IdName = null;
            Grid3.IsEditing = false;
            Grid3.Location = new Point(181, 445);
            Grid3.Margin = new Padding(4, 3, 4, 3);
            Grid3.Name = "Grid3";
            Grid3.Rows.Count = 1;
            Grid3.SelectedRows = null;
            Grid3.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            Grid3.Size = new Size(848, 245);
            Grid3.SortingType = SmartGrid.SortingType.Descending;
            Grid3.StyleInfo = resources.GetString("Grid3.StyleInfo");
            Grid3.TabIndex = 2;
            Grid3.UseCompatibleTextRendering = true;
            Grid3.ValidateDragTarget += Grid3_ValidateDragTarget;
            // 
            // Grid2
            // 
            Grid2.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.None;
            Grid2.AllowNodeMove = false;
            Grid2.AllowSorting = C1.Win.FlexGrid.AllowSortingEnum.MultiColumn;
            Grid2.ColumnInfo = "10,1,0,0,0,-1,Columns:0{Width:30;}\t4{Style:\"Format:\"\"N2\"\";\";}\t5{Style:\"Format:\"\"N2\"\";\";}\t6{Style:\"Format:\"\"N2\"\";\";}\t";
            Grid2.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 3;
            aggregateDefinition2.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition2.Column = 4;
            aggregateDefinition3.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition3.Column = 5;
            aggregateDefinition4.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition4.Column = 6;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            footerDescription1.Aggregates.Add(aggregateDefinition2);
            footerDescription1.Aggregates.Add(aggregateDefinition3);
            footerDescription1.Aggregates.Add(aggregateDefinition4);
            aggregateDefinition5.Aggregate = C1.Win.FlexGrid.AggregateEnum.Max;
            aggregateDefinition5.Caption = "Max: ";
            aggregateDefinition5.Column = 4;
            aggregateDefinition6.Aggregate = C1.Win.FlexGrid.AggregateEnum.Max;
            aggregateDefinition6.Caption = "Max: ";
            aggregateDefinition6.Column = 5;
            aggregateDefinition7.Aggregate = C1.Win.FlexGrid.AggregateEnum.Max;
            aggregateDefinition7.Caption = "Max: ";
            aggregateDefinition7.Column = 6;
            footerDescription2.Aggregates.Add(aggregateDefinition5);
            footerDescription2.Aggregates.Add(aggregateDefinition6);
            footerDescription2.Aggregates.Add(aggregateDefinition7);
            Grid2.Footers.Descriptions.Add(footerDescription1);
            Grid2.Footers.Descriptions.Add(footerDescription2);
            Grid2.Footers.Fixed = true;
            Grid2.Headers = null;
            Grid2.IdName = null;
            Grid2.IsEditing = false;
            Grid2.Location = new Point(181, 273);
            Grid2.Margin = new Padding(4, 3, 4, 3);
            Grid2.Name = "Grid2";
            Grid2.Rows.Count = 37;
            Grid2.SelectedRows = null;
            Grid2.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            Grid2.Size = new Size(848, 151);
            Grid2.SortingType = SmartGrid.SortingType.Descending;
            Grid2.StyleInfo = resources.GetString("Grid2.StyleInfo");
            Grid2.TabIndex = 1;
            Grid2.ToolTip = c1SuperTooltip1;
            Grid2.UseCompatibleTextRendering = true;
            // 
            // Grid
            // 
            Grid.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            Grid.AllowNodeMove = true;
            Grid.AllowSorting = C1.Win.FlexGrid.AllowSortingEnum.MultiColumn;
            Grid.AutoGenerateColumns = false;
            Grid.ColumnInfo = resources.GetString("Grid.ColumnInfo");
            Grid.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition8.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition8.Caption = "Всего: ";
            aggregateDefinition8.Column = 1;
            aggregateDefinition9.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition9.Caption = "Sum: ";
            aggregateDefinition9.Column = 2;
            aggregateDefinition10.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition10.Caption = "Sum:";
            aggregateDefinition10.Column = 3;
            footerDescription3.Aggregates.Add(aggregateDefinition8);
            footerDescription3.Aggregates.Add(aggregateDefinition9);
            footerDescription3.Aggregates.Add(aggregateDefinition10);
            Grid.Footers.Descriptions.Add(footerDescription3);
            Grid.Footers.Fixed = true;
            Grid.Headers = new string[]
    {
    "№\tНаименование\tDecimal\tDouble\tСтроки\tСтроки\tDate\tId\tParentId",
    "№\tНаименование\tDecimal\tDouble\tString1\tString2\tDate\tId\tParentId"
    };
            Grid.IdName = null;
            Grid.IsEditing = false;
            Grid.Location = new Point(181, 29);
            Grid.Margin = new Padding(4, 3, 4, 3);
            Grid.Name = "Grid";
            Grid.Rows.Count = 19;
            Grid.Rows.Fixed = 2;
            Grid.SelectedRows = null;
            Grid.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            Grid.Size = new Size(848, 215);
            Grid.SortingType = SmartGrid.SortingType.Descending;
            Grid.StyleInfo = resources.GetString("Grid.StyleInfo");
            Grid.TabIndex = 0;
            Grid.ToolTip = c1SuperTooltip1;
            Grid.Tree.Column = 1;
            Grid.Tree.Indent = 20;
            Grid.Tree.Style = C1.Win.FlexGrid.TreeStyleFlags.Symbols;
            Grid.UseCompatibleTextRendering = true;
            Grid.BeforeFilter += Grid_BeforeFilter;
            Grid.AfterFilter += Grid_AfterFilter;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1471, 755);
            Controls.Add(Grid3);
            Controls.Add(Grid2);
            Controls.Add(Grid);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)Grid3).EndInit();
            ((System.ComponentModel.ISupportInitialize)Grid2).EndInit();
            ((System.ComponentModel.ISupportInitialize)Grid).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private SmartGrid.SmartGrid Grid;
        private SmartGrid.SmartGrid Grid2;
        private C1.Win.SuperTooltip.C1SuperTooltip c1SuperTooltip1;
        private SmartGrid.SmartGrid Grid3;
    }
}
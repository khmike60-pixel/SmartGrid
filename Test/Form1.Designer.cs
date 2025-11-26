namespace Test
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            C1.Win.FlexGrid.FooterDescription footerDescription4 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition13 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition14 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition15 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition16 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.FooterDescription footerDescription5 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition17 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition18 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition19 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition20 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.FooterDescription footerDescription6 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition21 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition22 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition23 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition24 = new C1.Win.FlexGrid.AggregateDefinition();
            this.Tooltip1 = new C1.Win.SuperTooltip.C1SuperTooltip(this.components);
            this.Tooltip2 = new C1.Win.SuperTooltip.C1SuperTooltip(this.components);
            this.c1DropDownControl1 = new C1.Win.Input.C1DropDownControl();
            this.smartGrid2 = new SmartGrid.SmartGrid();
            this.smartGrid1 = new SmartGrid.SmartGrid();
            this.Grid = new SmartGrid.SmartGrid();
            ((System.ComponentModel.ISupportInitialize)(this.c1DropDownControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // Tooltip1
            // 
            this.Tooltip1.AutomaticDelay = 2000;
            this.Tooltip1.BackColor = System.Drawing.Color.LightCoral;
            this.Tooltip1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Tooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit;
            this.Tooltip1.RoundedCorners = true;
            // 
            // Tooltip2
            // 
            this.Tooltip2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Tooltip2.RightToLeft = System.Windows.Forms.RightToLeft.Inherit;
            // 
            // c1DropDownControl1
            // 
            //this.c1DropDownControl1.AutoOpen = true;
            //this.c1DropDownControl1.Cursor = System.Windows.Forms.Cursors.IBeam;
            //this.c1DropDownControl1.DropDownFormClassName = "Test.DropDownForm2";
            //this.c1DropDownControl1.GapHeight = 0;
            //this.c1DropDownControl1.ImagePadding = new System.Windows.Forms.Padding(0);
            //this.c1DropDownControl1.Location = new System.Drawing.Point(12, 279);
            //this.c1DropDownControl1.Name = "c1DropDownControl1";
            //this.c1DropDownControl1.Size = new System.Drawing.Size(200, 18);
            //this.c1DropDownControl1.TabIndex = 2;
            //this.c1DropDownControl1.Tag = null;
            //this.c1DropDownControl1.VisibleButtons = C1.Win.Input.DropDownControlButtonFlags.DropDown;
            // 
            // smartGrid2
            // 
            this.smartGrid2.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            this.smartGrid2.AllowNodeMove = false;
            this.smartGrid2.ColumnInfo = resources.GetString("smartGrid2.ColumnInfo");
            this.smartGrid2.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            this.smartGrid2.Headers = new string[] {
        "1\t2\t2\t2\t7\t7\t7\t...\t...\t...",
        "1\t3\t3\t4\t8\t8\t...\t...\t...\t...",
        "1\t5\t6\t...\t9\t9\t...\t...\t...\t...",
        "1\t5\t6\t...\t...\t9\t...\t...\t...\t..."};
            this.smartGrid2.IdName = null;
            this.smartGrid2.IsEditing = false;
            this.smartGrid2.Location = new System.Drawing.Point(469, 323);
            this.smartGrid2.Name = "smartGrid2";
            this.smartGrid2.Rows.Count = 10;
            this.smartGrid2.Rows.Fixed = 4;
            this.smartGrid2.SelectedRows = ((System.Collections.Generic.List<int>)(resources.GetObject("smartGrid2.SelectedRows")));
            this.smartGrid2.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            this.smartGrid2.Size = new System.Drawing.Size(580, 221);
            this.smartGrid2.SortingType = SmartGrid.SortingType.Descending;
            this.smartGrid2.StyleInfo = resources.GetString("smartGrid2.StyleInfo");
            this.smartGrid2.TabIndex = 4;
            // 
            // smartGrid1
            // 
            this.smartGrid1.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            this.smartGrid1.AllowNodeMove = false;
            this.smartGrid1.ColumnInfo = "3,0,0,0,0,-1,Columns:0{Width:30;Caption:\"1\";AllowMerging:True;}\t1{Caption:\"2\";All" +
    "owMerging:True;Style:\"DataType:System.Decimal;TextAlign:GeneralCenter;\";}\t2{Capt" +
    "ion:\"2\";AllowMerging:True;}\t";
            this.smartGrid1.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            this.smartGrid1.Headers = new string[] {
        "1\t2\t2",
        "1\t3\t4",
        "1\t3\t4"};
            this.smartGrid1.IdName = null;
            this.smartGrid1.IsEditing = false;
            this.smartGrid1.Location = new System.Drawing.Point(50, 367);
            this.smartGrid1.Name = "smartGrid1";
            this.smartGrid1.Rows.Count = 3;
            this.smartGrid1.Rows.Fixed = 3;
            this.smartGrid1.SelectedRows = ((System.Collections.Generic.List<int>)(resources.GetObject("smartGrid1.SelectedRows")));
            this.smartGrid1.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            this.smartGrid1.Size = new System.Drawing.Size(386, 136);
            this.smartGrid1.SortingType = SmartGrid.SortingType.Descending;
            this.smartGrid1.StyleInfo = resources.GetString("smartGrid1.StyleInfo");
            this.smartGrid1.TabIndex = 3;
            // 
            // Grid
            // 
            this.Grid.AllowFiltering = true;
            this.Grid.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            this.Grid.AllowNodeMove = false;
            this.Grid.AutoGenerateColumns = false;
            this.Grid.ColumnInfo = resources.GetString("Grid.ColumnInfo");
            this.Grid.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition13.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition13.Caption = "Sum: ";
            aggregateDefinition13.Column = 1;
            aggregateDefinition14.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition14.Caption = "Sum: ";
            aggregateDefinition14.Column = 2;
            aggregateDefinition15.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition15.Caption = "Sum: ";
            aggregateDefinition15.Column = 3;
            aggregateDefinition16.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition16.Caption = "Count: ";
            aggregateDefinition16.Column = 4;
            footerDescription4.Aggregates.Add(aggregateDefinition13);
            footerDescription4.Aggregates.Add(aggregateDefinition14);
            footerDescription4.Aggregates.Add(aggregateDefinition15);
            footerDescription4.Aggregates.Add(aggregateDefinition16);
            footerDescription4.Caption = "Footer1";
            aggregateDefinition17.Aggregate = C1.Win.FlexGrid.AggregateEnum.Max;
            aggregateDefinition17.Caption = "Max: ";
            aggregateDefinition17.Column = 1;
            aggregateDefinition18.Aggregate = C1.Win.FlexGrid.AggregateEnum.Max;
            aggregateDefinition18.Caption = "Max: ";    
            aggregateDefinition18.Column = 2;
            aggregateDefinition19.Aggregate = C1.Win.FlexGrid.AggregateEnum.Max;
            aggregateDefinition19.Caption = "Max: ";
            aggregateDefinition19.Column = 3;
            aggregateDefinition20.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition20.Caption = "Count: ";
            aggregateDefinition20.Column = 4;
            footerDescription5.Aggregates.Add(aggregateDefinition17);
            footerDescription5.Aggregates.Add(aggregateDefinition18);
            footerDescription5.Aggregates.Add(aggregateDefinition19);
            footerDescription5.Aggregates.Add(aggregateDefinition20);
            footerDescription5.Caption = "Footer2";
            aggregateDefinition21.Aggregate = C1.Win.FlexGrid.AggregateEnum.Min;
            aggregateDefinition21.Caption = "Min: ";
            aggregateDefinition21.Column = 1;
            aggregateDefinition22.Aggregate = C1.Win.FlexGrid.AggregateEnum.Min;
            aggregateDefinition22.Caption = "Min: ";
            aggregateDefinition22.Column = 2;
            aggregateDefinition23.Aggregate = C1.Win.FlexGrid.AggregateEnum.Min;
            aggregateDefinition23.Caption = "Min: ";
            aggregateDefinition23.Column = 3;
            aggregateDefinition24.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition24.Caption = "Count: ";
            aggregateDefinition24.Column = 4;
            footerDescription6.Aggregates.Add(aggregateDefinition21);
            footerDescription6.Aggregates.Add(aggregateDefinition22);
            footerDescription6.Aggregates.Add(aggregateDefinition23);
            footerDescription6.Aggregates.Add(aggregateDefinition24);
            footerDescription6.Caption = "Footer3";
            this.Grid.Footers.Descriptions.Add(footerDescription4);
            this.Grid.Footers.Descriptions.Add(footerDescription5);
            this.Grid.Footers.Descriptions.Add(footerDescription6);
            this.Grid.Footers.Fixed = true;
            this.Grid.Headers = new string[] {
        "1\tNumber of columns\tдесятичное число тест\tDecimal2\tString\tString\tDate\t...",
        "1\tNumber of columns\tдесятичное число тест\tDecimal2\tString1\tString2\tDate\t...",
        "1\tNumber of columns\tдесятичное число тест\tDecimal2\tString1\tString2\tDate\t..."};
            this.Grid.IdName = null;
            this.Grid.IsEditing = false;
            this.Grid.Location = new System.Drawing.Point(26, 18);
            this.Grid.Margin = new System.Windows.Forms.Padding(2);
            this.Grid.Name = "Grid";
            this.Grid.Rows.Count = 53;
            this.Grid.Rows.Fixed = 3;
            this.Grid.SelectedRows = ((System.Collections.Generic.List<int>)(resources.GetObject("Grid.SelectedRows")));
            this.Grid.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            this.Grid.ShowSortPosition = C1.Win.FlexGrid.ShowSortPositionEnum.Right;
            this.Grid.Size = new System.Drawing.Size(802, 230);
            this.Grid.SortingType = SmartGrid.SortingType.Descending;
            this.Grid.StyleInfo = resources.GetString("Grid.StyleInfo");
            this.Grid.TabIndex = 1;
            this.Grid.ToolTip = this.Tooltip1;
            this.Grid.BeforeSort += new C1.Win.FlexGrid.SortColEventHandler(this.Grid_BeforeSort);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 677);
            this.Controls.Add(this.smartGrid2);
            this.Controls.Add(this.smartGrid1);
            this.Controls.Add(this.c1DropDownControl1);
            this.Controls.Add(this.Grid);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.c1DropDownControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private SmartGrid.SmartGrid Grid;
        private C1.Win.SuperTooltip.C1SuperTooltip Tooltip1;
        private C1.Win.SuperTooltip.C1SuperTooltip Tooltip2;
        private C1.Win.Input.C1DropDownControl c1DropDownControl1;
        private SmartGrid.SmartGrid smartGrid1;
        private SmartGrid.SmartGrid smartGrid2;
    }
}
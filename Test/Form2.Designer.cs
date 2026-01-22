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
            c1SuperTooltip1 = new C1.Win.SuperTooltip.C1SuperTooltip(components);
            Grid3 = new SmartGrid.SmartGrid();
            buttonRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)Grid3).BeginInit();
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
            Grid3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Grid3.ColumnInfo = resources.GetString("Grid3.ColumnInfo");
            Grid3.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 2;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            Grid3.Footers.Descriptions.Add(footerDescription1);
            Grid3.Footers.Fixed = true;
            Grid3.Headers = new string[]
    {
    "0\t1\t2\t3\t4\t5\t6\t7\t8\t9",
    "0\t1\t2\t3\t4\t5\t6\t7\t8\t9"
    };
            Grid3.IdName = null;
            Grid3.IsEditing = false;
            Grid3.Location = new Point(14, 12);
            Grid3.Margin = new Padding(4, 3, 4, 3);
            Grid3.Name = "Grid3";
            Grid3.Rows.Count = 11;
            Grid3.Rows.Fixed = 2;
            Grid3.SelectedRows = null;
            Grid3.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            Grid3.Size = new Size(844, 426);
            Grid3.SortingType = SmartGrid.SortingType.Descending;
            Grid3.StyleInfo = resources.GetString("Grid3.StyleInfo");
            Grid3.TabIndex = 2;
            Grid3.UseCompatibleTextRendering = true;
            Grid3.ValidateDragTarget += Grid3_ValidateDragTarget;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonRefresh.Location = new Point(783, 444);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(75, 23);
            buttonRefresh.TabIndex = 3;
            buttonRefresh.Text = "Refresh";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(870, 479);
            Controls.Add(buttonRefresh);
            Controls.Add(Grid3);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)Grid3).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private C1.Win.SuperTooltip.C1SuperTooltip c1SuperTooltip1;
        private SmartGrid.SmartGrid Grid3;
        private Button buttonRefresh;
    }
}
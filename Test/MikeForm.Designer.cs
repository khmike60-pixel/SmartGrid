namespace Test
{
    partial class MikeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MikeForm));
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition2 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition3 = new C1.Win.FlexGrid.AggregateDefinition();
            smartGrid1 = new SmartGrid.SmartGrid();
            ((System.ComponentModel.ISupportInitialize)smartGrid1).BeginInit();
            SuspendLayout();
            // 
            // smartGrid1
            // 
            smartGrid1.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGrid1.AllowNodeMove = false;
            smartGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            smartGrid1.AutoGenerateColumns = false;
            smartGrid1.ColumnInfo = resources.GetString("smartGrid1.ColumnInfo");
            smartGrid1.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition1.Column = 4;
            aggregateDefinition2.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition2.Column = 5;
            aggregateDefinition3.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition3.Column = 6;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            footerDescription1.Aggregates.Add(aggregateDefinition2);
            footerDescription1.Aggregates.Add(aggregateDefinition3);
            smartGrid1.Footers.Descriptions.Add(footerDescription1);
            smartGrid1.Footers.Fixed = true;
            smartGrid1.Headers = new string[]
    {
    " \tНаименование товаров, работ, услуг\tНаименование товаров, работ, услуг\tНаименование товаров, работ, услуг\tКол-во\tЦена\tСумма\tНДС\tНДС\tСумма с НДС",
    " \tНаименование\tИКПУ\tЕд.изм.\tКол-во\tЦена\tСумма\t% НДС\tСумма НДС\tСумма с НДС",
    " \tНаименование\tИКПУ\tЕд.изм.\tКол-во\tЦена\tСумма\t% НДС\tСумма НДС\tСумма с НДС"
    };
            smartGrid1.IdName = null;
            smartGrid1.IsEditing = false;
            smartGrid1.Location = new Point(12, 84);
            smartGrid1.Name = "smartGrid1";
            smartGrid1.Rows.Count = 15;
            smartGrid1.Rows.Fixed = 3;
            smartGrid1.SelectedRows = (List<int>)resources.GetObject("smartGrid1.SelectedRows");
            smartGrid1.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGrid1.Size = new Size(776, 354);
            smartGrid1.SortingType = SmartGrid.SortingType.Descending;
            smartGrid1.StyleInfo = resources.GetString("smartGrid1.StyleInfo");
            smartGrid1.TabIndex = 0;
            smartGrid1.RowColChange += smartGrid1_RowColChange;
            // 
            // MikeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(smartGrid1);
            Name = "MikeForm";
            Text = "MikeForm";
            Load += MikeForm_Load;
            ((System.ComponentModel.ISupportInitialize)smartGrid1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SmartGrid.SmartGrid smartGrid1;
    }
}
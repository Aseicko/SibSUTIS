namespace DatabaseManagementSystem
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataDisplayMain = new System.Windows.Forms.DataGridView();
            this.RecordNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordStreetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordHouseNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordApartmentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordSettlementDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxCurrentPage = new System.Windows.Forms.TextBox();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonPreviousPage = new System.Windows.Forms.Button();
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.buttonEncode = new System.Windows.Forms.Button();
            this.buttonGoToRecord = new System.Windows.Forms.Button();
            this.buttonChangeSortState = new System.Windows.Forms.Button();
            this.textBoxSearchTree = new System.Windows.Forms.TextBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelSearchMain = new System.Windows.Forms.Label();
            this.labelSearchTree = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataDisplayMain)).BeginInit();
            this.groupOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataDisplayMain
            // 
            this.dataDisplayMain.AllowUserToAddRows = false;
            this.dataDisplayMain.AllowUserToDeleteRows = false;
            this.dataDisplayMain.AllowUserToResizeColumns = false;
            this.dataDisplayMain.AllowUserToResizeRows = false;
            this.dataDisplayMain.ColumnHeadersHeight = 32;
            this.dataDisplayMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataDisplayMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RecordNumber,
            this.RecordID,
            this.RecordFullName,
            this.RecordStreetName,
            this.RecordHouseNumber,
            this.RecordApartmentNumber,
            this.RecordSettlementDate});
            this.dataDisplayMain.Location = new System.Drawing.Point(12, 38);
            this.dataDisplayMain.Name = "dataDisplayMain";
            this.dataDisplayMain.ReadOnly = true;
            this.dataDisplayMain.RowHeadersVisible = false;
            this.dataDisplayMain.RowHeadersWidth = 50;
            this.dataDisplayMain.RowTemplate.Height = 25;
            this.dataDisplayMain.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataDisplayMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataDisplayMain.Size = new System.Drawing.Size(760, 532);
            this.dataDisplayMain.TabIndex = 0;
            this.dataDisplayMain.TabStop = false;
            // 
            // RecordNumber
            // 
            this.RecordNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RecordNumber.FillWeight = 4F;
            this.RecordNumber.HeaderText = "Number";
            this.RecordNumber.Name = "RecordNumber";
            this.RecordNumber.ReadOnly = true;
            this.RecordNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RecordID
            // 
            this.RecordID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RecordID.FillWeight = 4F;
            this.RecordID.HeaderText = "ID";
            this.RecordID.Name = "RecordID";
            this.RecordID.ReadOnly = true;
            this.RecordID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RecordFullName
            // 
            this.RecordFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RecordFullName.FillWeight = 16F;
            this.RecordFullName.HeaderText = "Full Name";
            this.RecordFullName.Name = "RecordFullName";
            this.RecordFullName.ReadOnly = true;
            this.RecordFullName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RecordStreetName
            // 
            this.RecordStreetName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RecordStreetName.FillWeight = 8F;
            this.RecordStreetName.HeaderText = "Street Name";
            this.RecordStreetName.Name = "RecordStreetName";
            this.RecordStreetName.ReadOnly = true;
            this.RecordStreetName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RecordHouseNumber
            // 
            this.RecordHouseNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RecordHouseNumber.FillWeight = 4F;
            this.RecordHouseNumber.HeaderText = "House Number";
            this.RecordHouseNumber.Name = "RecordHouseNumber";
            this.RecordHouseNumber.ReadOnly = true;
            this.RecordHouseNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RecordApartmentNumber
            // 
            this.RecordApartmentNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RecordApartmentNumber.FillWeight = 4F;
            this.RecordApartmentNumber.HeaderText = "Apartment Number";
            this.RecordApartmentNumber.Name = "RecordApartmentNumber";
            this.RecordApartmentNumber.ReadOnly = true;
            this.RecordApartmentNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RecordSettlementDate
            // 
            this.RecordSettlementDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RecordSettlementDate.FillWeight = 8F;
            this.RecordSettlementDate.HeaderText = "Settlement Date";
            this.RecordSettlementDate.Name = "RecordSettlementDate";
            this.RecordSettlementDate.ReadOnly = true;
            this.RecordSettlementDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // textBoxCurrentPage
            // 
            this.textBoxCurrentPage.Location = new System.Drawing.Point(347, 576);
            this.textBoxCurrentPage.Name = "textBoxCurrentPage";
            this.textBoxCurrentPage.Size = new System.Drawing.Size(100, 20);
            this.textBoxCurrentPage.TabIndex = 0;
            this.textBoxCurrentPage.TabStop = false;
            this.textBoxCurrentPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCurrentPage.TextChanged += new System.EventHandler(this.TextBoxCurrentPage_TextChanged);
            this.textBoxCurrentPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RemoveNotDigitFromInput);
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Location = new System.Drawing.Point(453, 573);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(25, 25);
            this.buttonNextPage.TabIndex = 3;
            this.buttonNextPage.Text = ">";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            this.buttonNextPage.Click += new System.EventHandler(this.ButtonNextPage_Click);
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.Location = new System.Drawing.Point(316, 573);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.Size = new System.Drawing.Size(25, 25);
            this.buttonPreviousPage.TabIndex = 2;
            this.buttonPreviousPage.Text = "<";
            this.buttonPreviousPage.UseVisualStyleBackColor = true;
            this.buttonPreviousPage.Click += new System.EventHandler(this.ButtonPreviousPage_Click);
            // 
            // groupOptions
            // 
            this.groupOptions.Controls.Add(this.buttonEncode);
            this.groupOptions.Controls.Add(this.buttonGoToRecord);
            this.groupOptions.Controls.Add(this.buttonChangeSortState);
            this.groupOptions.Location = new System.Drawing.Point(12, 604);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(760, 50);
            this.groupOptions.TabIndex = 1;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Options";
            // 
            // buttonEncode
            // 
            this.buttonEncode.Location = new System.Drawing.Point(318, 19);
            this.buttonEncode.Name = "buttonEncode";
            this.buttonEncode.Size = new System.Drawing.Size(100, 25);
            this.buttonEncode.TabIndex = 9;
            this.buttonEncode.Text = "Encode";
            this.buttonEncode.UseVisualStyleBackColor = true;
            this.buttonEncode.Click += new System.EventHandler(this.ButtonEncode_Click);
            // 
            // buttonGoToRecord
            // 
            this.buttonGoToRecord.Location = new System.Drawing.Point(112, 19);
            this.buttonGoToRecord.Name = "buttonGoToRecord";
            this.buttonGoToRecord.Size = new System.Drawing.Size(200, 25);
            this.buttonGoToRecord.TabIndex = 8;
            this.buttonGoToRecord.Text = "Go to Record";
            this.buttonGoToRecord.UseVisualStyleBackColor = true;
            this.buttonGoToRecord.Click += new System.EventHandler(this.ButtonGoToRecord_Click);
            // 
            // buttonChangeSortState
            // 
            this.buttonChangeSortState.Location = new System.Drawing.Point(6, 19);
            this.buttonChangeSortState.Name = "buttonChangeSortState";
            this.buttonChangeSortState.Size = new System.Drawing.Size(100, 25);
            this.buttonChangeSortState.TabIndex = 4;
            this.buttonChangeSortState.Text = "SortState";
            this.buttonChangeSortState.UseVisualStyleBackColor = true;
            this.buttonChangeSortState.Click += new System.EventHandler(this.ButtonChangeSortState_Click);
            // 
            // textBoxSearchTree
            // 
            this.textBoxSearchTree.Location = new System.Drawing.Point(672, 12);
            this.textBoxSearchTree.Name = "textBoxSearchTree";
            this.textBoxSearchTree.Size = new System.Drawing.Size(100, 20);
            this.textBoxSearchTree.TabIndex = 1;
            this.textBoxSearchTree.TextChanged += new System.EventHandler(this.TextBoxSearchTree_TextChanged);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(121, 12);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(444, 20);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.TextBoxSearch_TextChanged);
            // 
            // labelSearchMain
            // 
            this.labelSearchMain.AutoSize = true;
            this.labelSearchMain.Location = new System.Drawing.Point(12, 15);
            this.labelSearchMain.Name = "labelSearchMain";
            this.labelSearchMain.Size = new System.Drawing.Size(103, 13);
            this.labelSearchMain.TabIndex = 6;
            this.labelSearchMain.Text = "Search Street Name";
            // 
            // labelSearchTree
            // 
            this.labelSearchTree.AutoSize = true;
            this.labelSearchTree.Location = new System.Drawing.Point(571, 15);
            this.labelSearchTree.Name = "labelSearchTree";
            this.labelSearchTree.Size = new System.Drawing.Size(95, 13);
            this.labelSearchTree.TabIndex = 8;
            this.labelSearchTree.Text = "Apartment Number";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 661);
            this.Controls.Add(this.labelSearchTree);
            this.Controls.Add(this.labelSearchMain);
            this.Controls.Add(this.textBoxSearchTree);
            this.Controls.Add(this.groupOptions);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonPreviousPage);
            this.Controls.Add(this.textBoxCurrentPage);
            this.Controls.Add(this.buttonNextPage);
            this.Controls.Add(this.dataDisplayMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Management System";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataDisplayMain)).EndInit();
            this.groupOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataDisplayMain;
        private System.Windows.Forms.TextBox textBoxCurrentPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonPreviousPage;
        private System.Windows.Forms.GroupBox groupOptions;
        private System.Windows.Forms.Button buttonChangeSortState;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordStreetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordHouseNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordApartmentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordSettlementDate;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.TextBox textBoxSearchTree;
        private System.Windows.Forms.Label labelSearchMain;
        private System.Windows.Forms.Label labelSearchTree;
        private System.Windows.Forms.Button buttonGoToRecord;
        private System.Windows.Forms.Button buttonEncode;
    }
}

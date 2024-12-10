using DatabaseManagementSystem.src;
using System;
using System.Windows.Forms;

namespace DatabaseManagementSystem
{
    public partial class FormMain : Form
    {
        const string PathToFile = "testBase4.dat";
        readonly ManagerData managerData = new ManagerData();

        public FormMain()
        {
            InitializeComponent();
        }

        private void UpdateDisplayData()
        {
            managerData.FormatForDisplay(managerData.CurrentPage, textBoxSearch.Text, textBoxSearchTree.Text, Record => Record.StrStreetName);
            managerData.DisplayToGrid(managerData.CurrentRecords, dataDisplayMain);
            textBoxCurrentPage.Text = managerData.CurrentPage.ToString();

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            managerData.Execute(PathToFile);

            buttonChangeSortState.Text = SortStates.Sorted.ToString();

            UpdateDisplayData();
        }

        private void ButtonNextPage_Click(object sender, EventArgs e)
        {
            managerData.CurrentPage++;
            if (managerData.CurrentPage >= managerData.TotalPages)
            {
                managerData.CurrentPage = 0;
            }

            UpdateDisplayData();

        }

        private void ButtonPreviousPage_Click(object sender, EventArgs e)
        {
            managerData.CurrentPage--;
            if (managerData.CurrentPage < 0)
            {
                managerData.CurrentPage = managerData.TotalPages - 1;
            }

            UpdateDisplayData();

        }

        private void TextBoxCurrentPage_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBoxCurrentPage.Text, out int page);
            page = Math.Min(Math.Max(page, 0), managerData.TotalPages - 1);

            managerData.CurrentPage = page;

            UpdateDisplayData();

        }

        private void RemoveNotDigitFromInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

        }

        private void ButtonChangeSortState_Click(object sender, EventArgs e)
        {
            managerData.DisplaySorted = !managerData.DisplaySorted;

            buttonChangeSortState.Text = (managerData.DisplaySorted ? SortStates.Sorted : SortStates.Unsorted).ToString();

            UpdateDisplayData();

        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            UpdateDisplayData();

        }

        private void TextBoxSearchTree_TextChanged(object sender, EventArgs e)
        {
            UpdateDisplayData();

        }

        private void ButtonGoToRecord_Click(object sender, EventArgs e)
        {
            CreateGoToForm(out Form promptForm, out TextBox inputBox);

            DialogResult result = promptForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                int.TryParse(inputBox.Text, out int value);
                if (value < 1 || value > managerData.TotalRecords)
                {
                    MessageBox.Show("Record not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                managerData.CurrentPage = (value - 1) / ManagerData.RecordsPerPage;
                UpdateDisplayData();
                int index = value % ManagerData.RecordsPerPage;
                dataDisplayMain.Rows[index == 0 ? ManagerData.RecordsPerPage - 1 : index - 1].Selected = true;

            }
        }

        private void ButtonEncode_Click(object sender, EventArgs e)
        {
            CreateEncodeForm(out Form encodeForm);
            encodeForm.ShowDialog();

        }

        private void CreateGoToForm(out Form promptForm, out TextBox inputBox)
        {
            promptForm = new Form()
            {
                Width = 216,
                Height = 180,
                Text = "Go to Record",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Padding = new Padding(10)
            };
            Label info = new Label()
            {
                Text = $"Input record number from {1} to {managerData.FoundSortedIndexes.Count}",
                Top = 20,
                Left = 10,
                Width = 180
            };
            promptForm.Controls.Add(info);

            inputBox = new TextBox()
            {
                Left = 10,
                Top = info.Bottom + 10,
                Width = 180
            };
            promptForm.Controls.Add(inputBox);

            Button okButton = new Button()
            {
                Text = "Ok",
                Left = 10,
                Width = 80,
                Top = inputBox.Bottom + 20,
                DialogResult = DialogResult.OK
            };
            promptForm.Controls.Add(okButton);

            Button cancelButton = new Button()
            {
                Text = "Cancel",
                Left = okButton.Right + 20,
                Width = 80,
                Top = inputBox.Bottom + 20,
                DialogResult = DialogResult.Cancel
            };
            promptForm.Controls.Add(cancelButton);

            promptForm.AcceptButton = okButton;
            promptForm.CancelButton = cancelButton;
        }

        private void CreateEncodeForm(out Form encodeForm)
        {
            encodeForm = new Form
            {
                Width = 512,
                Height = 512,
                Text = "Encoded symbols",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Padding = new Padding(10)
            };

            var dataGridView = CreateDataGridView(new string[] { "Symbol", "Frequency", "Code word", "Code length" }, 384);
            encodeForm.Controls.Add(dataGridView);

            var gridFeatures = CreateDataGridView(new string[] { "Kraft Inequality", "Entropy", "Av. Height", "Redundancy", "Full Text", "Encoded Text", "Compression Ratio" }, 50);
            gridFeatures.Top = dataGridView.Bottom + 10;
            encodeForm.Controls.Add(gridFeatures);

            var temp = new ManagerEncoding();
            temp.ReadFromFile(PathToFile);
            temp.GenerateCodes();
            temp.DisplayToGrid(dataGridView);
            temp.EncodeText(PathToFile);

            gridFeatures.Rows.Add(
                temp.CheckKraftInequality().ToString(),
                $"{temp.CalculateEntropy():F5}",
                $"{temp.CalculateAverageHeight():F5}",
                $"{temp.CalculateAverageHeight() - temp.CalculateEntropy():F5}",
                $"{temp.textFull.Length * 8}",
                $"{temp.textEncoded.Length}",
                $"{(double)temp.textFull.Length * 8 / temp.textEncoded.Length:F3}"
            );
        }

        private DataGridView CreateDataGridView(string[] columnHeaders, int height)
        {
            var dataGridView = new DataGridView
            {
                Width = 496,
                Height = height,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                ScrollBars = ScrollBars.Vertical,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            };

            foreach (var header in columnHeaders)
            {
                dataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = header });
            }

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            return dataGridView;
        }

    }

}

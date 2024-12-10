using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DatabaseManagementSystem.src
{
    internal class ManagerData
    {
        const int RecordSize = 64;
        internal const int RecordsPerPage = 20;

        internal int CurrentPage = 0;
        internal int TotalRecords = 0;
        internal int TotalPages = 0;

        internal bool DisplaySorted = true;

        internal List<Record> AllRecords = new List<Record>();
        internal List<Record> CurrentRecords = new List<Record>();

        internal List<int> AllIndexes = new List<int>();
        internal List<int> FoundIndexes = new List<int>();

        internal List<int> AllSortedIndexes = new List<int>();
        internal List<int> FoundSortedIndexes = new List<int>();

        readonly ManagerSearching managerSearching = new ManagerSearching();
        readonly ManagerSorting managerSorting = new ManagerSorting();

        public void Execute(string pathToFile)
        {
            ReadFromFile(pathToFile);

            managerSorting.RadixSort(AllRecords, ref AllSortedIndexes, Record => Record.StrHouseNumber);
            managerSorting.RadixSort(AllRecords, ref AllSortedIndexes, Record => Record.StrStreetName);

        }

        private void ReadFromFile(string pathToFile)
        {
            if (!File.Exists(pathToFile))
            {
                MessageBox.Show("File does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] bytesFromFile = File.ReadAllBytes(pathToFile);

            if (bytesFromFile.Length == 0)
            {
                MessageBox.Show("The file is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int recordCount = bytesFromFile.Length / RecordSize;
            byte[] temp = new byte[RecordSize];

            for (int i = 0; i < recordCount; i++)
            {
                Array.Copy(bytesFromFile, i * RecordSize, temp, 0, RecordSize);

                Record newRecord = new Record(i);
                newRecord.ParseBytes(temp);

                AllRecords.Add(newRecord);
                AllIndexes.Add(i);
                TotalRecords++;
            }
            TotalPages = (int)Math.Ceiling((double)TotalRecords / RecordsPerPage);
            AllSortedIndexes = new List<int>(AllIndexes);
        }

        internal void FormatForDisplay<T>(int currentPage, T searchInAll, T searchInTree, Func<Record, T> getFieldData)
        {
            if (currentPage < 0 || currentPage >= TotalPages) return;
            CurrentRecords.Clear();

            FoundSortedIndexes = managerSearching.SearchAllByField(searchInAll, AllRecords, AllSortedIndexes, getFieldData);

            ManagerTree temp = new ManagerTree(AllRecords);
            temp.CreateTree(FoundSortedIndexes);

            if (searchInAll.ToString().Length > 0)
            {
                FoundSortedIndexes = temp.Inorder();
                FoundSortedIndexes.Reverse();
            }

            if (searchInTree.ToString().Length > 0 && int.TryParse(searchInTree.ToString(), out int searchValue))
            {
                FoundSortedIndexes = SearchInTree(temp, searchValue);
            }

            if (FoundSortedIndexes.Count == 0) return;

            FoundIndexes = new List<int>(FoundSortedIndexes);
            FoundIndexes.Sort();

            TotalRecords = FoundSortedIndexes.Count;
            TotalPages = (int)Math.Ceiling((double)TotalRecords / RecordsPerPage);

            if (currentPage > TotalPages - 1) currentPage = TotalPages - 1;
            CurrentPage = currentPage;

            UpdateCurrentRecords(currentPage, searchInAll);
        }

        private List<int> SearchInTree(ManagerTree tree, int searchValue)
        {
            tree.Search(tree.TreeRoot, Record => int.Parse(Record.StrApartmentNumber), searchValue);
            var foundIndexes = new List<int>(tree.FoundIndexes);
            foundIndexes.Reverse();
            return foundIndexes;
        }

        private void UpdateCurrentRecords<T>(int currentPage, T searchInAll)
        {
            for (int i = currentPage * RecordsPerPage; i < Math.Min(currentPage * RecordsPerPage + RecordsPerPage, TotalRecords); i++)
            {
                CurrentRecords.Add(AllRecords[DisplaySorted ?
                    (searchInAll == null ? AllSortedIndexes[i] : FoundSortedIndexes[i]) :
                    (searchInAll == null ? AllIndexes[i] : FoundIndexes[i])]);
            }
        }

        internal void DisplayToGrid(List<Record> dataToDisplay, DataGridView gridToDisplay)
        {
            int counter = CurrentPage * RecordsPerPage + 1;
            gridToDisplay.Rows.Clear();

            foreach (var record in dataToDisplay)
            {
                gridToDisplay.Rows.Add
                (
                    counter++,
                    record.ID,
                    record.StrFullName,
                    record.StrStreetName,
                    record.StrHouseNumber,
                    record.StrApartmentNumber,
                    record.StrSettlementDate
                );
            }

            gridToDisplay.ClearSelection();

        }

    }

}

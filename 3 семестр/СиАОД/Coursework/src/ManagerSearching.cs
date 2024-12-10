using System;
using System.Collections.Generic;

namespace DatabaseManagementSystem.src
{
    internal class ManagerSearching
    {
        internal List<int> FoundRecords = new List<int>();

        internal List<int> SearchAllByField<T>(T searchFor, List<Record> listData, List<int> listIndex, Func<Record, T> getFieldData)
        {
            List<int> output = new List<int>();

            if (searchFor == null) return output;

            int firstIndex = SearchFirstIndexByField(searchFor, listData, listIndex, getFieldData);
            if (firstIndex == -1) return output;

            for (int i = firstIndex; i < listIndex.Count; i++)
            {
                if (getFieldData(listData[listIndex[i]]).ToString().StartsWith(searchFor.ToString()))
                {
                    output.Add(listIndex[i]);
                }
                else break;
            }

            return output;
        }

        internal int SearchFirstIndexByField<T>(T searchFor, List<Record> listData, List<int> listIndex, Func<Record, T> getFieldData)
        {
            int indexLeft = 0, indexRight = listIndex.Count - 1;
            int indexMiddle;
            Record middleRecord;
            T searchField;

            while (indexLeft <= indexRight)
            {
                indexMiddle = indexLeft + (indexRight - indexLeft) / 2;

                middleRecord = listData[listIndex[indexMiddle]];
                searchField = getFieldData(middleRecord);

                if (string.Compare(searchField.ToString().Substring(0, searchFor.ToString().Length), searchFor.ToString()) < 0)
                {
                    indexLeft = indexMiddle + 1;
                }
                else
                {
                    indexRight = indexMiddle - 1;
                }
            }
            if (indexLeft >= listData.Count) return -1;
            return string.Compare(getFieldData(listData[listIndex[indexLeft]]).ToString().Substring(0, searchFor.ToString().Length), searchFor.ToString()) == 0 ? indexLeft : -1;
        }

    }

}

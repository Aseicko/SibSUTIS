using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseManagementSystem.src
{
    enum SortStates
    {
        Sorted,
        Unsorted
    }

    internal class ManagerSorting
    {
        internal void RadixSort<T>(List<Record> listData, ref List<int> listIndex, Func<Record, T> getFieldData)
        {
            int maxBytes = listData.Max(record => getFieldData(record).ToString().Length);

            for (int bytePosition = maxBytes - 1; bytePosition >= 0; bytePosition--)
            {
                CountSort(listData, ref listIndex, bytePosition, getFieldData);
            }
        }

        private void CountSort<T>(List<Record> listData, ref List<int> listIndex, int bytePosition, Func<Record, T> getFieldData)
        {
            var count = new int[256];
            var output = new List<int>(new int[listIndex.Count]);

            foreach (var index in listIndex)
            {
                var fieldData = getFieldData(listData[index]);
                byte byteValue = GetByteAtPosition(fieldData, bytePosition);
                count[byteValue]++;
            }

            for (int i = 1; i < 256; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = listIndex.Count - 1; i >= 0; i--)
            {
                var index = listIndex[i];
                var fieldData = getFieldData(listData[index]);
                byte byteValue = GetByteAtPosition(fieldData, bytePosition);

                output[count[byteValue] - 1] = index;
                count[byteValue]--;
            }

            listIndex.Clear();
            listIndex.AddRange(output);
        }

        private byte GetByteAtPosition<T>(T fieldData, int bytePosition)
        {
            byte[] bytes;

            if (fieldData is string strData)
            {
                bytes = Encoding.GetEncoding(866).GetBytes(strData);
            }
            else if (fieldData is int intData)
            {
                bytes = new byte[intData];
            }
            else
            {
                bytes = fieldData as byte[];
            }

            return (byte)(bytePosition < bytes.Length ? bytes[bytePosition] : 0);

        }

    }

}

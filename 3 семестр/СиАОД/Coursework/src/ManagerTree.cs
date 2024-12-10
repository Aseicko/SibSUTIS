using System;
using System.Collections.Generic;

namespace DatabaseManagementSystem.src
{
    internal class TreeNode
    {
        internal int RecordIndex { get; set; }
        internal int Balance { get; set; }
        internal TreeNode LeftTree { get; set; }
        internal TreeNode RightTree { get; set; }

        internal TreeNode(int recordIndex)
        {
            RecordIndex = recordIndex;
            Balance = 0;
            LeftTree = null;
            RightTree = null;
        }

    }

    internal class ManagerTree
    {
        private readonly List<Record> AllRecords;
        private bool VR = true, HR = true;
        internal List<int> FoundIndexes;

        public TreeNode TreeRoot;

        internal ManagerTree(List<Record> listRecords)
        {
            AllRecords = listRecords;

        }

        public void CreateTree(List<int> listIndex)
        {
            foreach (var item in listIndex)
            {
                Insert(item);
            }
        }

        public void Insert(int value)
        {
            TreeRoot = InsertRecursive(TreeRoot, value, Record => int.Parse(Record.StrApartmentNumber));
        }

        public List<int> Inorder()
        {
            List<int> indexes = new List<int>();

            InorderRecursive(TreeRoot, ref indexes);

            return indexes;
        }

        public void Search<T>(TreeNode root, Func<Record, T> getFieldData, T valueToFind)
        {
            FoundIndexes = new List<int>();

            if (valueToFind.ToString().Length == 0 || root == null)
            {
                return;
            }

            T currentFieldData = getFieldData(AllRecords[root.RecordIndex]);

            if (Comparer<T>.Default.Compare(currentFieldData, valueToFind) == 0)
            {
                Search(root.RightTree, getFieldData, valueToFind);
                FoundIndexes.Add(root.RecordIndex);
            }
            else if (Comparer<T>.Default.Compare(currentFieldData, valueToFind) < 0)
            {
                Search(root.LeftTree, getFieldData, valueToFind);
            }
            else
            {
                Search(root.RightTree, getFieldData, valueToFind);
            }
        }

        private TreeNode InsertRecursive<T>(TreeNode root, int newRecordIndex, Func<Record, T> getFieldData)
        {
            if (root == null)
            {
                TreeNode newNode = new TreeNode(newRecordIndex) { Balance = 0 };
                VR = true;
                return newNode;
            }

            T currentFieldData = getFieldData(AllRecords[root.RecordIndex]);
            T newFieldData = getFieldData(AllRecords[newRecordIndex]);

            if (Comparer<T>.Default.Compare(currentFieldData, newFieldData) < 0)
            {
                root.LeftTree = InsertRecursive(root.LeftTree, newRecordIndex, getFieldData);
            }
            else
            {
                root.RightTree = InsertRecursive(root.RightTree, newRecordIndex, getFieldData);
            }

            if (VR)
            {
                if (Comparer<T>.Default.Compare(currentFieldData, newFieldData) < 0)
                {
                    root = PerformLeftRotation(root);
                }
                else
                {
                    root = PerformRightRotation(root);
                }

                VR = false;
                HR = true;
            }

            return root;
        }

        private TreeNode PerformLeftRotation(TreeNode root)
        {
            if (root.Balance == 0)
            {
                TreeNode temp = root.LeftTree;
                root.LeftTree = temp.RightTree;
                temp.RightTree = root;
                root = temp;
                temp.Balance = 1;
                VR = false;
                HR = true;
            }
            else
            {
                root.Balance = 0;
                VR = true;
                HR = false;
            }
            return root;
        }

        private TreeNode PerformRightRotation(TreeNode root)
        {
            if (HR)
            {
                if (root.Balance == 1)
                {
                    TreeNode temp = root.RightTree;
                    root.Balance = 0;
                    temp.Balance = 0;
                    root.RightTree = temp.LeftTree;
                    temp.LeftTree = root;
                    root = temp;
                    VR = true;
                    HR = false;
                }
                else
                {
                    HR = false;
                }
            }
            else
            {
                root.Balance = 1;
                VR = false;
                HR = true;
            }

            return root;
        }

        private void InorderRecursive(TreeNode root, ref List<int> listIndexes)
        {
            if (root == null) return;

            InorderRecursive(root.LeftTree, ref listIndexes);
            listIndexes.Add(root.RecordIndex);
            InorderRecursive(root.RightTree, ref listIndexes);
        }

    }
}

using System.Drawing;
using System;
using System.Diagnostics.Metrics;

namespace ProjectDataStructure.Models
{
    public class Project2Service
    {
        public DataStructureArray GenerateIdentityMatrix(string matrixString)
        {
            var rows = matrixString.Split('\n');
            int rowsCount = rows.Length;
            int k = 0;
            DataStructureArray matrix = new DataStructureArray(rowsCount);

            for (int i = 0; i < rowsCount; i++)
            {
                var values = rows[i].Split(' ');
                int columnsCount = values.Length;
                int count = 0;
                DataStructureArray row = new DataStructureArray(rowsCount);

                for (int j = 0; j < columnsCount; j++)
                {
                    int value;
                    if (int.TryParse(values[j], out value) && value != 0)
                    {
                        row.Insert(i + 1, count);
                        row.Insert(j + 1, count + 1);
                        row.Insert(value, count + 2);
                        count += 3;
                    }
                }
                while (k < rowsCount)
                {
                    if (row.FindWithId(k) == null)
                        row.Delete(k);
                    k++;
                }
                matrix.Insert(row, i);
                k = 0;
            }
            k = 0;
            while(k < rowsCount)
            {
                if(matrix.FindWithId(k) == null)
                    matrix.Delete(k);
                k++;
            }
            return matrix;
        }






        public class DataStructureArray
        {
            private object[] array;
            private int size;

            public DataStructureArray(int capacity)
            {
                array = new object[capacity];
                size = 0;
            }

            public int GetSize()
            {
                return size;
            }

            public void Insert(object item, int index)
            {
                if (index < 0 || index > size)
                    throw new IndexOutOfRangeException("Invalid index");

                if (size == array.Length)
                    ResizeArray();

                for (int i = size - 1; i >= index; i--)
                    array[i + 1] = array[i];

                array[index] = item;
                size++;
            }

            public object Delete(int index)
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException("Invalid index");

                object deletedItem = array[index];

                for (int i = index; i < size - 1; i++)
                    array[i] = array[i + 1];

                size--;

                return deletedItem;
            }

            public object Find(int item)
            {
                for (int i = 0; i < size; i++)
                {
                    if (array[i].Equals(item))
                    {
                        return array[i];
                    }
                }

                return -1;
            }

            public object FindWithId(int id)
            {
                for (int i = 0; i < size; i++)
                {
                    if (i == id)
                    {
                        return array[i];
                    }
                }

                return -1;
            }

            private void ResizeArray()
            {
                int newCapacity = array.Length * 2;
                Array.Resize(ref array, newCapacity);
            }
        }

    }
}

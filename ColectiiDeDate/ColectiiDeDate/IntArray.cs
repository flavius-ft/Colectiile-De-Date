using System;

namespace ColectiiDeDate
{
    class IntArray
    {
        private int[] array;
        private int countElements;

        public IntArray()
        {
            array = new int[4];
        }

        public int Count()
        {
            return countElements;
        }

        public void Resize()
        {
            if (countElements != array.Length)
            {
                return;
            }

            Array.Resize(ref array, array.Length * 2);
        }

        public void Add(int element)
        {
            Resize();
            array[countElements] = element;
            countElements++;
        }

        public int Element(int index)
        {
            return array[index];
        }

        public void SetElement(int index, int element)
        {
            array[index] = element;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) >= 0;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < countElements; i++)
            {
                if (array[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            Resize();
            ShiftRight(index);

            array[index] = element;
        }

        public void Clear()
        {
           for (int i = countElements - 1; i >= 0; i--)
            {
                RemoveAt(i);
            }
        }

        public void Remove(int element)
        {
            RemoveAt(IndexOf(element));
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Array.Resize(ref array, array.Length - 1);
            countElements--;
        }

        internal void ShiftRight(int index)
        {
            for (int i = array.Length - 1; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }

        internal void ShiftLeft(int index)
        {
            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
        }
    }
}

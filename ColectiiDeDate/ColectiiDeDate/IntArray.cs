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

        public int Count
        {
            get
            {
            return countElements;
            }
        }

        public int this[int index]
        {
            get => array[index];
            set => array[index] = value;
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
            countElements = 0;
        }

        public void Remove(int element)
        {
            RemoveAt(IndexOf(element));
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
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

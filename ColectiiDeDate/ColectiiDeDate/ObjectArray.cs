using System;
using System.Collections;

namespace ColectiiDeDate
{
    class ObjectArray : IEnumerable
    {
        private object[] array;

        public ObjectArray()
        {
            array = new object[4];
        }

        public int Count { get; private set; }

        public virtual object this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public ObjArrayEnum GetEnumerator()
        {
            return new ObjArrayEnum(array);
        }

        public virtual void Add(object element)
        {
            Resize();
            array[Count] = element;
            Count++;
        }

        public bool Contains(object element)
        {
            return IndexOf(element) >= 0;
        }

        public int IndexOf(object element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, object element)
        {
            Resize();
            ShiftRight(index);

            array[index] = element;
            Count++;
        }

        public void Clear()
        {
            Count = 0;
        }

        public void Remove(object element)
        {
            RemoveAt(IndexOf(element));
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Count--;
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

        private void Resize()
        {
            if (Count != array.Length)
            {
                return;
            }

            Array.Resize(ref array, array.Length * 2);
        }
    }
}

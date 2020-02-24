using System;
using System.Collections;
using System.Collections.Generic;

namespace ColectiiDeDate
{
    class List<T> : IList<T>
    {
        private T[] array;

        public List()
        {
            array = new T[4];
        }

        public int Count { get; private set; }

        public bool IsReadOnly => ((IList<T>)array).IsReadOnly;

        public virtual T this[int index]
        {
            get
            {
                if (index < Count)
                {
                    return array[index];
                }

                throw new ArgumentException("Error");
            }

            set => array[index] = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual void Add(T element)
        {
            Resize();
            array[Count] = element;
            Count++;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) >= 0;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, T element)
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

        public void Remove(T element)
        {
            RemoveAt(IndexOf(element));
        }

        public void RemoveAt(int index)
        {
            if (index > Count - 1)
            {
                throw new ArgumentException("HERE IS NO ELEMENT");
            }

            ShiftLeft(index);

            Count--;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((IList<T>)this.array).CopyTo(array, arrayIndex);
        }

        bool ICollection<T>.Remove(T item)
        {
            return ((IList<T>)array).Remove(item);
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

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

        public bool IsReadOnly { get; private set; }

        public virtual T this[int index]
        {
            get
            {
                    return array[index];
            }

            set
            {
                if (IsReadOnly)
                {
                    throw new NotSupportedException();
                }
                else if (index > Count - 1)
                {
                    throw new ArgumentException("");
                }

                array[index] = value;
            }
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
            if (IsReadOnly)
            {
                throw new NotSupportedException();
            }

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
            if (IsReadOnly)
            {
                throw new NotSupportedException();
            }

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
            else if (IsReadOnly)
            {
                throw new NotSupportedException();
            }

            ShiftLeft(index);

            Count--;
        }

        public List<T> ListIsReadOnly()
        {
            List<T> secondArray = new List<T>();

            for (int i = 0; i < Count; i++)
            {
                secondArray.Insert(i, array[i]);
            }

            secondArray.IsReadOnly = true;

            return secondArray;
        }

        public void CopyTo(T[] secondArray, int arrayIndex)
        {
            if (secondArray == null)
            {
                throw new ArgumentNullException("secondArray");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("arrayIndex");
            }

            if (secondArray.Length < array.Length - arrayIndex)
            {
                throw new ArgumentException("The number of elements in the source List is greater than the available space");
            }

            int k = 0;
            for (int i = arrayIndex; i < array.Length; i++)
            {
                secondArray[k] = array[i];
                k++;
            }
        }

        bool ICollection<T>.Remove(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException();
            }

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

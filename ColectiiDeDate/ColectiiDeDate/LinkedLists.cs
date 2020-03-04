using System;
using System.Collections;
using System.Collections.Generic;

namespace ColectiiDeDate
{
    class LinkedLists<T> : ICollection<T>
    {
        private readonly Node<T> head = new Node<T>();

        public LinkedLists()
        {
            head.Next = head;
            head.Previous = head;
        }

        public int Count { get; set; }

        public bool IsReadOnly { get; }

        public void Add(T item)
        {
            Node<T> newElement = new Node<T>()
            {
                Value = item,
                Previous = head.Previous
            };
            head.Previous.Next = newElement;
            head.Previous = newElement;
            newElement.Next = head;

            Count++;
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Contains(T item)
        {
            for (Node<T> temp = head.Next; temp != head; temp = temp.Next)
            {
                if (temp.Value.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var arrayList = GetEnumerator();
            int i = 0;
            int k = 0;

            for (Node<T> temp = head.Next; temp != head; temp = temp.Next)
            {
                arrayList.MoveNext();
                if (k >= arrayIndex)
                {
                    array[i] = arrayList.Current;
                    i++;
                }

                k++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (Node<T> temp = head.Next; temp != head; temp = temp.Next)
            {
                yield return temp.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool RemoveFirst()
        {
            return Remove(head.Next.Value);
        }

        public bool RemoveLast()
        {
            return Remove(head.Previous.Value);
        }

        public bool Remove(Node<T> node)
        {
                if (node != null || FoundNodeBy(node.Value) != null)
                {
                    node.Previous.Next = node.Next;
                    node.Next.Previous = node.Previous;
                    node.Previous = null;
                    node.Next = null;
                    Count--;
                    return true;
                }

                return false;
        }

        public bool Remove(T item)
        {
            return Remove(FoundNodeBy(item));
        }

        internal Node<T> FoundNodeBy(T item)
        {
            for (Node<T> temp = head.Next; temp != head; temp = temp.Next)
            {
                if (temp.Value.Equals(item))
                {
                    return temp;
                }
            }

            return null;
        }
    }
}

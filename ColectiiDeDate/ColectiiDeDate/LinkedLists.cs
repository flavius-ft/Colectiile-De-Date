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

        public int Count { get; private set; }

        public Node<T> First => head.Next;

        public Node<T> Last => head.Previous;

        public bool IsReadOnly { get; }

        public void Add(T item)
        {
            AddLast(item);
        }

        public void AddFirst(Node<T> firstNode)
        {
            AddBefore(head.Next, firstNode);
        }

        public void AddFirst(T item)
        {
            var newNode = new Node<T> { Value = item, List = this };

            AddFirst(newNode);
        }

        public void AddLast(Node<T> lastNode)
        {
            AddBefore(head, lastNode);
        }

        public void AddLast(T item)
        {
            AddLast(new Node<T> { Value = item, List = this });
        }

        public void AddAfter(Node<T> node, Node<T> newNode)
        {
            AddBefore(node.Next, newNode);
        }

        public void AddAfter(Node<T> node, T item)
        {
            var newNode = new Node<T>() { Value = item, List = this };

            AddAfter(node, newNode);
        }

        public void AddBefore(Node<T> thisNode, Node<T> newNode)
        {
            if (newNode.Value == null)
            {
                throw new ArgumentNullException("newNode");
            }

            if (newNode.List != this)
            {
                throw new InvalidOperationException();
            }

            newNode.Next = thisNode;
            newNode.Previous = thisNode.Previous;
            thisNode.Previous.Next = newNode;
            thisNode.Previous = newNode;

            Count++;
        }

        public void AddBefore(Node<T> node, T item)
        {
            if (node.Value == null && Count != 0)
            {
                throw new ArgumentNullException("node");
            }

            if (node.List != this)
            {
                throw new InvalidOperationException();
            }

            var newNode = new Node<T>() { Value = item, List = this };

            AddBefore(node, newNode);
        }

        public void Clear()
        {
            head.Next = head;
            head.Previous = head;

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
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("arrayIndex");
            }

            if (array.Length < Count + arrayIndex)
            {
                throw new ArgumentException("TheNumberOfElementsIsGreaterThanAvailableSpace");
            }

            var arrayList = GetEnumerator();
            int i = arrayIndex;

            for (; arrayIndex < Count + i; arrayIndex++)
            {
                arrayList.MoveNext();
                array[arrayIndex] = arrayList.Current;
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
            return Remove(head.Next);
        }

        public bool RemoveLast()
        {
            return Remove(head.Previous);
        }

        public bool Remove(Node<T> node)
        {
            if (node.Value == null)
            {
                throw new ArgumentNullException("node");
            }

            if (node.List != this)
            {
                throw new InvalidOperationException();
            }

            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
            Count--;

            return !Contains(node.Value);
        }

        public bool Remove(T item)
        {
            for (Node<T> temp = head.Next; temp != head; temp = temp.Next)
            {
                if (temp.Value.Equals(item))
                {
                    return Remove(temp);
                }
            }

            return false;
        }

        public Node<T> FindLast(T item)
        {
            for (Node<T> temp = head.Previous; temp != head; temp = temp.Previous)
            {
                if (temp.Value.Equals(item))
                {
                    return temp;
                }
            }

            return null;
        }

        public Node<T> Find(T item)
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

﻿using System;
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
            throw new NotImplementedException();
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
            var duplicate = GetArray(this);

            int k = 0;
            for (int i = arrayIndex; i < duplicate.Length; i++)
            {
                array[k] = duplicate[i];
                k++;
            }
        }

        public T[] GetArray(LinkedLists<T> list)
        {
            var arrayList = list.GetEnumerator();
            var array = new T[Count];
            int i = 0;

            for (Node<T> temp = head.Next; temp != head; temp = temp.Next)
            {
                arrayList.MoveNext();
                array[i] = arrayList.Current;
                i++;
            }

            return array;
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

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
    }
}

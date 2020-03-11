using System;
using System.Collections;
using System.Collections.Generic;

namespace ColectiiDeDate
{
    class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly int[] buckets;

        private readonly Elements<TKey, TValue>[] elements;

        public MyDictionary(int length)
        {
            buckets = new int[length];
            Array.Fill(buckets, -1);

            elements = new Elements<TKey, TValue>[length];
        }

        public ICollection<TKey> Keys { get; }

        public ICollection<TValue> Values { get; }

        public int Count { get; set; }

        public bool IsReadOnly { get; set; }

        public TValue this[TKey key] { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Add(TKey key, TValue value)
        {
            elements[Count] = new Elements<TKey, TValue>
            {
                Key = key,
                Value = value,
                Next = buckets[HashCode(key)]
            };

            buckets[key.GetHashCode()] = Count;

            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            int bucketIndex = HashCode(item.Key);
            int bucketValue = buckets[bucketIndex];
            int elementIndex = bucketValue;
            if (bucketValue != -1)
            {
                while (elementIndex != -1)
                {
                    if (elements[elementIndex].Key.Equals(item.Key))
                    {
                        return true;
                    }

                    elementIndex = elements[elementIndex].Next;
                }
            }

            return false;
        }

        public bool ContainsKey(TKey key)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new System.NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        internal int HashCode(TKey key)
        {
            return key.GetHashCode() % buckets.Length;
        }
    }
}

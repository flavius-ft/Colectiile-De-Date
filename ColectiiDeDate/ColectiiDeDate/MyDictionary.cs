﻿using System.Collections;
using System.Collections.Generic;

namespace ColectiiDeDate
{
    class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        public ICollection<TKey> Keys => throw new System.NotImplementedException();

        public ICollection<TValue> Values => throw new System.NotImplementedException();

        public int Count { get; set; }

        public bool IsReadOnly => throw new System.NotImplementedException();

        public TValue this[TKey key] { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Add(TKey key, TValue value)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
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
    }
}

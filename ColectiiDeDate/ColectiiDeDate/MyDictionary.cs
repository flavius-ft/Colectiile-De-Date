using System;
using System.Collections;
using System.Collections.Generic;

namespace ColectiiDeDate
{
    class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly int[] buckets;

        private readonly Elements<TKey, TValue>[] elements;

        private int freeIndex = -1;

        public MyDictionary(int length)
        {
            buckets = new int[length];
            Array.Fill(buckets, -1);

            elements = new Elements<TKey, TValue>[length];
        }

        public ICollection<TKey> Keys
        {
            get
            {
                int i = 0;
                TKey[] keys = new TKey[Count];
                foreach (var key in this)
                {
                    keys[i] = key.Key;
                    i++;
                }

                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                int i = 0;
                TValue[] values = new TValue[Count];
                foreach (var val in this)
                {
                    values[i] = val.Value;
                    i++;
                }

                return values;
            }
        }

        public int Count { get; set; }

        public bool IsReadOnly { get; }

        public TValue this[TKey key]
        {
            get
            {
                if (!TryGetValue(key, out TValue val))
                {
                    throw new KeyNotFoundException();
                }

                return val;
            }

            set
            {
                if (ContainsKey(key))
                {
                    elements[GetElementIndex(key)].Value = value;
                }
                else
                {
                Add(key, value);
                }
            }
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            if (ContainsKey(key))
            {
                throw new ArgumentException("The key already exists in the dictionary");
            }

            if (freeIndex != -1)
            {
                int index = elements[freeIndex].Next;

                CreateElement(freeIndex, key, value, buckets[HashCode(key)]);

                buckets[HashCode(key)] = freeIndex;
                freeIndex = index;
            }
            else
            {
                CreateElement(Count, key, value, buckets[HashCode(key)]);

                buckets[HashCode(key)] = Count;
            }

            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Count = 0;
            Array.Fill(buckets, -1);
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return TryGetValue(item.Key, out TValue val) && val.Equals(item.Value);
        }

        public bool ContainsKey(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            var item = SearchElement(key);
            return item.Key.Equals(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            int i = arrayIndex;

            for (var arrayDictionary = GetEnumerator(); arrayIndex < Count + i; arrayIndex++)
            {
                arrayDictionary.MoveNext();
                array[arrayIndex] = arrayDictionary.Current;
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                    for (int elemIndex = buckets[i]; elemIndex != -1; elemIndex = elements[elemIndex].Next)
                    {
                        yield return new KeyValuePair<TKey, TValue>(elements[elemIndex].Key, elements[elemIndex].Value);
                    }
            }
        }

        public bool Remove(TKey key)
        {
            if (TryGetValue(key, out TValue val))
            {
                Remove(new KeyValuePair<TKey, TValue>(key, val));
            }

            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (item.Key == null)
            {
                throw new ArgumentNullException("item");
            }

            int bucketIndex = HashCode(item.Key);
            int index = buckets[bucketIndex];

            for (int elementIndex = elements[index].Next; elementIndex != -1;
            elementIndex = elements[elementIndex].Next)
            {
                if (elements[elementIndex].Key.Equals(item.Key))
                {
                    elements[index].Next = elements[elementIndex].Next;

                    elements[elementIndex].Next = freeIndex;
                    freeIndex = elementIndex;
                    Count--;

                    return true;
                }
            }

            if (elements[index].Key.Equals(item.Key))
            {
                elements[index].Key = default(TKey);
                elements[index].Value = default(TValue);
                buckets[bucketIndex] = elements[index].Next;
                elements[index].Next = freeIndex;
                freeIndex = index;
                Count--;

                return true;
            }

            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            var element = SearchElement(key);

            if (element.Key.Equals(default(TKey)))
            {
                value = default(TValue);
                return false;
            }

            value = element.Value;
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal int GetElementIndex(TKey key)
        {
            int bucketIndex = HashCode(key);

            for (int elementIndex = buckets[bucketIndex]; elementIndex != -1; elementIndex = elements[elementIndex].Next)
            {
                if (elements[elementIndex].Key.Equals(key))
                {
                    return elementIndex;
                }
            }

            return -1;
        }

        internal Elements<TKey, TValue> CreateElement(int index, TKey key, TValue value, int nextIndex)
        {
            elements[index] = new Elements<TKey, TValue>
            {
                Key = key,
                Value = value,
                Next = nextIndex
            };

            return elements[index];
        }

        internal KeyValuePair<TKey, TValue> SearchElement(TKey key)
        {
            int bucketIndex = HashCode(key);

            for (int elementIndex = buckets[bucketIndex]; elementIndex != -1; elementIndex = elements[elementIndex].Next)
            {
                if (elements[elementIndex].Key.Equals(key))
                {
                    return new KeyValuePair<TKey, TValue>(elements[elementIndex].Key, elements[elementIndex].Value);
                }
            }

            return new KeyValuePair<TKey, TValue>(default(TKey), default(TValue));
        }

        internal int HashCode(TKey key)
        {
            return key.GetHashCode() % buckets.Length;
        }
    }
}

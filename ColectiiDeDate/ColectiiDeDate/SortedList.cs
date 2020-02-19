using System;

namespace ColectiiDeDate
{
    class SortedList<T> : List<T>
        where T : IComparable<T>
    {
        public override T this[int index]
        {
            set
            {
                if (ValueIsEqualOrGreater(value, index - 1)
                    && ValueIsEqualOrSmaller(value, index + 1))
                {
                    base[index] = value;
                }
            }
        }

        public override void Add(T element)
        {
            Insert(BinarySearch(element), element);
        }

        public override void Insert(int index, T element)
        {
            if (index != BinarySearch(element))
            {
                return;
            }

            base.Insert(index, element);
        }

        public int BinarySearch(T element)
        {
            int start = 0;
            int end = Count;
            int mid;

            if (Count != 0 && element.CompareTo(base[Count - 1]) > 0)
            {
                return Count;
            }

            while (start <= end)
            {
                mid = (start + end) / 2;
                if (mid == 0 && IsEqualOrSmaller(element, base[mid]))
                {
                    return mid;
                }
                else if (mid != 0 && IsBetween(base[mid - 1], element, base[mid]))
                {
                    return mid;
                }
                else if (element.CompareTo(base[mid]) < 0)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return Count;
        }

        internal bool ValueIsEqualOrSmaller(T value, int index)
        {
            return value.CompareTo(GetElement(index - 1, value)) == 0 ||
                value.CompareTo(GetElement(index + 1, value)) < 0;
        }

        internal bool ValueIsEqualOrGreater(T value, int index)
        {
            return value.CompareTo(GetElement(index - 1, value)) == 0 ||
                value.CompareTo(GetElement(index + 1, value)) > 0;
        }

        internal bool IsGreaterOrEqual(T element, T compare)
        {
            return element.CompareTo(compare) == 0 ||
                    element.CompareTo(compare) > 0;
        }

        internal bool IsEqualOrSmaller(T element, T compare)
        {
            return element.CompareTo(compare) == 0 ||
                    element.CompareTo(compare) < 0;
        }

        internal bool IsBetween(T before, T element, T after)
        {
            return element.CompareTo(before) > 0 &&
                    element.CompareTo(after) < 0;
        }

        private T GetElement(int index, T defaultValue)
        {
            return index >= 0 && index < Count
                ? base[index]
                : defaultValue;
        }
    }
}

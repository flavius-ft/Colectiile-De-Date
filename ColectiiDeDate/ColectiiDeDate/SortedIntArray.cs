namespace ColectiiDeDate
{
    class SortedIntArray : IntArray
    {
        public override int this[int index]
        {
            set
                {
                bool indexIsFirst = index == 0 && value <= this[index];
                bool indexIsLast = index == (Count - 1) && value >= this[index];
                bool limits = indexIsFirst || indexIsLast;

                if (limits)
                {
                base[index] = value;
                }
                 else if (value <= this[index + 1] && value >= this[index - 1])
                {
                base[index] = value;
                }
            }
        }

        public override void Add(int element)
        {
            Insert(BinarySearch(element), element);
        }

        public override void Insert(int index, int element)
        {
            if (index != BinarySearch(element))
            {
                return;
            }

            base.Insert(index, element);
        }

        public int BinarySearch(int element)
        {
            int start = 0;
            int end = Count;
            int mid;

            if (Count != 0 && element > this[Count - 1])
            {
                return Count;
            }

            while (start <= end)
            {
                mid = (start + end) / 2;
                if (this[mid] == element || element < this[mid] && mid == 0)
                {
                    return mid;
                }
                else if (element < this[mid] && element > this[mid - 1])
                {
                    return mid;
                }
                else if (element < this[mid])
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
    }
}

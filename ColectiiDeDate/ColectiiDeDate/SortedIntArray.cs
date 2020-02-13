namespace ColectiiDeDate
{
    class SortedIntArray : IntArray
    {
        public override void Add(int element)
        {
            Insert(BinarySearch(element), element);
        }

        public override void Insert(int index, int element)
        {
            base.Insert(BinarySearch(element), element);
        }

        public int BinarySearch(int element)
        {
            int start = 0;
            int end = Count;
            int mid;
            while (start <= end)
            {
                mid = (start + end) / 2;
                if (this[mid] == element || element < this[mid] && mid == 0)
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

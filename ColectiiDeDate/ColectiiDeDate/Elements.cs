namespace ColectiiDeDate
{
    class Elements<TKey, TValue>
    {
        public Elements()
        {
        }

        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public int Next { get; set; }
    }
}

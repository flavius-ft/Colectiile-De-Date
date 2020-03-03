namespace ColectiiDeDate
{
    class Node<T>
    {
        public Node()
        {
        }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }

        public T Value { get; set; }
    }
}

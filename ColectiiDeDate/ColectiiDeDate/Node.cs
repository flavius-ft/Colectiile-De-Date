namespace ColectiiDeDate
{
    class Node
    {
        public Node(object element)
        {
            this.Value = element;
        }

        public Node Next { get; set; }

        public Node Previous { get; set; }

        public object Value { get; set; }
    }
}

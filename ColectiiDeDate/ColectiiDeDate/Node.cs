using System;

namespace ColectiiDeDate
{
    class Node
    {
        public Node(object element, Node next, Node previous)
        {
            this.ElementValue = element;
            this.Next = next;
            this.Previous = previous;
        }

        public object ElementValue { get; set; }

        public Node Next { get; set; }

        public Node Previous { get; set; }
    }
}

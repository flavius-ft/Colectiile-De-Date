using Xunit;
using System;

namespace ColectiiDeDate
{
    public class LinkedListsTests
    {
        [Fact]
        public void AddAnElementEndCheckIfIsAdded()
        {
            var list = new LinkedLists<int> { 1 };

            Assert.Contains(1, list);
        }

        [Fact]
        public void AddSecondElementEndCheckIfIsAdded()
        {
            var list = new LinkedLists<int> { 1 };
            list.Add(2);

            Assert.Contains(2, list);
        }

        [Fact]
        public void CheckIfContainsReturFalse()
        {
            var list = new LinkedLists<int> { 1 };
            list.Add(2);
            bool answer = list.Contains(3);

            Assert.False(answer);
        }

        [Fact]
        public void EnumerateTheElementsFromListReturnFirstElement()
        {
            var list = new LinkedLists<int> { 1 };
            list.Add(2);
            list.Add(3);

            var enumList = list.GetEnumerator();
            enumList.MoveNext();

            Assert.Equal(1, enumList.Current);
        }

        [Fact]
        public void EnumerateTheElementsFromListReturnMiddleElement()
        {
            var list = new LinkedLists<int> { 1, 2, 3 };

            var enumList = list.GetEnumerator();
            enumList.MoveNext();
            enumList.MoveNext();

            Assert.Equal(2, enumList.Current);
        }

        [Fact]
        public void EnumerateTheElementsFromListReturnLastElement()
        {
            var list = new LinkedLists<int> { 1, 2, 3 };

            var enumList = list.GetEnumerator();
            enumList.MoveNext();
            enumList.MoveNext();
            enumList.MoveNext();

            Assert.Equal(3, enumList.Current);
        }

        [Fact]
        public void CopyALinkedListIntoArray()
        {
            var list = new LinkedLists<int> { 1, 2, 3 };
            const int index = 1;
            int[] array = new int[list.Count + index];
            list.CopyTo(array, index);

            Assert.Equal(3, array[3]);
        }

        [Fact]
        public void RemoveSpecificItemAndReturnTrue()
        {
            var list = new LinkedLists<int> { 1, 2, 3, 4, 5 };

            Assert.True(list.Remove(3));
        }

        [Fact]
        public void RemoveSpecificItemAndReturnFalse()
        {
            var list = new LinkedLists<int> { 1, 2, 3, 4, 5 };

            Assert.False(list.Remove(6));
        }

        [Fact]
        public void RemoveFirstItemAndReturnTrue()
        {
            var list = new LinkedLists<int> { 1, 2, 3, 4, 5 };

            Assert.True(list.RemoveFirst());
        }

        [Fact]
        public void RemoveFirstItemAndReturnFalse()
        {
            var list = new LinkedLists<int>();

            Assert.False(list.RemoveFirst());
        }

        [Fact]
        public void RemoveLastItemAndReturnTrue()
        {
            var list = new LinkedLists<int> { 1, 2, 3, 4, 5 };

            Assert.True(list.RemoveLast());
            Assert.DoesNotContain(5, list);
        }

        [Fact]
        public void RemoveLastItemAndReturnFalse()
        {
            var list = new LinkedLists<int>();

            Assert.False(list.RemoveLast());
        }

        [Fact]
        public void RemoveNodeReturnTrue()
        {
            var list = new LinkedLists<int> { 1, 2, 3, 4, 5 };

            Assert.True(list.Remove(4));
        }

        [Fact]
        public void AddNewNodeAfterSpecificNode()
        {
            var list = new LinkedLists<int> { 1, 2, 4, 5 };
            var newNode = new Node<int> { Value = 3 };
            var array = new int[5];

            list.AddAfter(list.Find(2), newNode);
            list.CopyTo(array, 0);

            Assert.Equal(3, array[2]);
        }

        [Fact]
        public void AddNewItemAfterSpecificNode()
        {
            var list = new LinkedLists<int> { 1, 2, 4, 5 };
            var array = new int[5];
            var actualNode = list.Find(2);

            list.AddAfter(actualNode, 3);
            list.CopyTo(array, 0);

            Assert.Equal(3, array[2]);
        }

        [Fact]
        public void AddNewNodeBeforeSpecificNode()
        {
            var list = new LinkedLists<int> { 1, 2, 4, 5 };
            var newNode = new Node<int> { Value = 3 };
            var array = new int[5];

            list.AddBefore(list.Find(4), newNode);
            list.CopyTo(array, 0);

            Assert.Equal(3, array[2]);
        }

        [Fact]
        public void AddNewItemBeforSpecificNode()
        {
            var list = new LinkedLists<int> { 1, 2, 4, 5 };
            var array = new int[5];
            var actualNode = list.Find(4);

            list.AddBefore(actualNode, 3);
            list.CopyTo(array, 0);

            Assert.Equal(3, array[2]);
        }

        [Fact]
        public void AddNodeOnFirstPosition()
        {
            var list = new LinkedLists<int> { 2, 4, 5 };
            var array = new int[4];
            Node<int> newNode = new Node<int> { Value = 1 };

            list.AddFirst(newNode);
            list.CopyTo(array, 0);

            Assert.Equal(1, array[0]);
        }

        [Fact]
        public void AddNodeOnLastPosition()
        {
            var list = new LinkedLists<int> { 2, 4, 5 };
            var array = new int[4];
            Node<int> newNode = new Node<int> { Value = 6 };

            list.AddLast(newNode);
            list.CopyTo(array, 0);

            Assert.Equal(6, array[3]);
        }

        [Fact]
        public void ArgumentNullExceptionOnAddBeforeWhenNodeIsNull()
        {
            var list = new LinkedLists<string> { "2", "4", "5" };
            var node = new Node<string> { Value = null };

            Assert.Throws<ArgumentNullException>(() => list.AddBefore(node, "5"));
        }

        [Fact]
        public void ArgumentNullExceptionOnAddAfterWhenNewNodeIsNull()
        {
            var list = new LinkedLists<string> { "2", "4", "5" };
            var node = new Node<string> { Value = "4" };
            var newNode = new Node<string>();

            Assert.Throws<ArgumentNullException>(() => list.AddAfter(node, newNode));
        }

        [Fact]
        public void ArgumentNullExceptionOnCopyToMethod()
        {
            var list = new LinkedLists<int> { 1, 2, 4, 5 };
            const int index = 1;
            int[] array = null;

            Assert.Throws<ArgumentNullException>(() => list.CopyTo(array, index));
        }

        [Fact]
        public void CopyToArgumentOutOfRangeException()
        {
            var list = new LinkedLists<int> { 1, 2, 4, 5 };
            const int index = -1;
            int[] array = new int[list.Count + index];

            Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(array, index));
        }

        [Fact]
        public void CopyToArgumentExceptionTheNumberOfElementsIsGreaterThanAvailableSpace()
        {
            var list = new LinkedLists<int> { 1, 2, 4, 5 };
            const int index = 2;
            int[] array = new int[list.Count];

            Assert.Throws<ArgumentException>(() => list.CopyTo(array, index));
        }

        [Fact]
        public void RemoveArgumentNullException()
        {
            var list = new LinkedLists<string> { "1", "2" };
            var node = new Node<string>();

            Assert.Throws<ArgumentNullException>(() => list.Remove(node));
        }

        [Fact]
        public void RemoveInvalidOperationException()
        {
            var list = new LinkedLists<string> { "1", "2" };
            var node = new Node<string> { Value = "3" };

            Assert.Throws<InvalidOperationException>(() => list.Remove(node));
        }
    }
}

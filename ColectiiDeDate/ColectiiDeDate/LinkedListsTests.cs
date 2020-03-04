﻿using Xunit;

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
            int[] array = new int[list.Count - index];
            list.CopyTo(array, index);

            Assert.Equal(3, array[1]);
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
    }
}

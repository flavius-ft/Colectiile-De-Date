using Xunit;

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
    }
}

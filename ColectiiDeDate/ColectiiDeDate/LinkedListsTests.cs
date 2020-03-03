using Xunit;

namespace ColectiiDeDate
{
    public class LinkedListsTests
    {
        [Fact]
        public void AddAnElementEndCheckIfIsAdded()
        {
            var list = new LinkedLists<int> { 1 };
            list.Add(2);

            Assert.Contains(1, list);
        }
    }
}

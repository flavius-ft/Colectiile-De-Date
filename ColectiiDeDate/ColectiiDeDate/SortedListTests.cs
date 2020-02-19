using Xunit;

namespace ColectiiDeDate
{
    public class SortedListTests
    {
        [Fact]
        public void InsertAnElementtoArray()
        {
            var number = new SortedList<int> { 1, 2, 4 };
            number.Insert(2, 3);

            Assert.Equal(3, number[2]);
        }

        [Fact]
        public void InsertOnFirstPosition()
        {
            var number = new SortedList<int> { 2, 4 };
            number.Insert(0, 1);

            Assert.Equal(1, number[0]);
        }

        [Fact]
        public void InsertOnLastPosition()
        {
            var number = new SortedList<int> { 2, 4 };
            number.Insert(2, 4);

            Assert.Equal(4, number[2]);
        }

        [Fact]
        public void ChangeElementOnSpecificPosition()
        {
            var number = new SortedList<int> { 2, 4 };
            number[0] = 5;

            Assert.Equal(2, number[0]);
        }

        [Fact]
        public void AddElementInSortedList()
        {
            var number = new SortedList<int> { 2, 3, 5 };
            number.Add(4);

            Assert.Equal(4, number[2]);
        }
    }
}

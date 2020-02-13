using Xunit;

namespace ColectiiDeDate
{
    public class SortedIntArrayTests
    {
        [Fact]
        public void AddAnElementInASortedArray()
        {
            var sortArray = new SortedIntArray();
            sortArray.Add(3);
            sortArray.Add(2);
            sortArray.Add(1);
            sortArray.Add(4);

            Assert.Equal(4, sortArray[3]);
        }

        [Fact]
        public void InsertElementInSortedArray()
        {
            var sortArray = new SortedIntArray();
            sortArray.Add(1);
            sortArray.Add(2);
            sortArray.Add(3);

            sortArray.Insert(2, 4);

            Assert.Equal(3, sortArray[2]);
        }

        [Fact]
        public void InsertElementInSortedArrayReturnFalse()
        {
            var sortArray = new SortedIntArray();
            sortArray.Add(1);
            sortArray.Add(2);
            sortArray.Add(3);

            sortArray.Insert(2, 4);

            Assert.False(sortArray.Contains(4));
        }

        [Fact]
        public void AddRandomNumbersReturnSortedArray()
        {
            var sortArray = new SortedIntArray();
            sortArray.Add(3);
            sortArray.Add(1);
            sortArray.Add(5);
            sortArray.Add(4);
            sortArray.Add(7);
            sortArray.Add(9);

            Assert.Equal(5, sortArray[3]);
        }
    }
}

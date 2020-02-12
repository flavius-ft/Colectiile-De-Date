using Xunit;

namespace ColectiiDeDate
{
    public class SortedIntArrayTests
    {
        [Fact]
        public void InsertAnElementInASortedArray()
        {
            var sortArray = new SortedIntArray();
            sortArray.Add(3);
            sortArray.Add(2);
            sortArray.Add(1);

            Assert.Equal(1, sortArray[0]);
        }
    }
}

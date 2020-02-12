using Xunit;

namespace ColectiiDeDate
{
    public class SortedIntArrayTests
    {
        [Fact]
        public void InsertAnElementInASortedArray()
        {
            var array = new IntArray();
            array.Add(1);

            Assert.True(array.Contains(1));
        }
    }
}

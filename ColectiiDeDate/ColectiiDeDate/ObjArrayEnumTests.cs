using Xunit;

namespace ColectiiDeDate
{
    public class ObjArrayEnumTests
    {
        [Fact]
        public void EnumerateAnEmptyArray()
        {
            var array = new List<string>();

            Assert.Empty(array);
        }

        [Fact]
        public void EnumerateAnArrayWithTwoElementsReturnSecondElement()
        {
            var array = new List<int> { 2, 4 };

            var testArray = array.GetEnumerator();
            testArray.MoveNext();
            testArray.MoveNext();

            Assert.Equal(4, testArray.Current);
        }

        [Fact]
        public void EnumerateAnArrayWithTwoElementsReturnFirstElement()
        {
            var array = new List<int> { 2, 4 };

            var testArray = array.GetEnumerator();
            testArray.MoveNext();

            Assert.Equal(2, testArray.Current);
        }

        [Fact]
        public void EnumerateAnArrayObjectElementsReturnSecondElement()
        {
            var array = new List<object> { 2, "4", 'd' };

            var testArray = array.GetEnumerator();
            testArray.MoveNext();
            testArray.MoveNext();

            Assert.Equal("4", testArray.Current);
        }
    }
}

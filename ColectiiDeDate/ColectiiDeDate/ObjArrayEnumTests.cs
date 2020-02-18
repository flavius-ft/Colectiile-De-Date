using Xunit;

namespace ColectiiDeDate
{
    public class ObjArrayEnumTests
    {
        [Fact]
        public void EnumerateAnEmptyArray()
        {
            var array = new ObjectArray();

            Assert.Empty(array);
        }

        [Fact]
        public void EnumerateAnArrayWithTwoElementsReturnSecondElement()
        {
            var array = new ObjectArray { 2, 4 };

            var testArray = array.GetEnumerator();
            testArray.MoveNext();
            testArray.MoveNext();

            Assert.Equal(4, testArray.Current);
        }

        [Fact]
        public void EnumerateAnArrayWithTwoElementsReturnFirstElement()
        {
            var array = new ObjectArray { 2, 4 };

            var testArray = array.GetEnumerator();
            testArray.MoveNext();

            Assert.Equal(2, testArray.Current);
        }

        [Fact]
        public void EnumerateAnArrayWithTwoElementsAplyResetMethodRetunrNumberOfElements()
        {
            var array = new ObjectArray { 2, 4 };

            var testArray = array.GetEnumerator();
            testArray.MoveNext();
            testArray.MoveNext();

            testArray.Reset();
            testArray.MoveNext();

            Assert.Equal(2, testArray.Current);
        }
    }
}

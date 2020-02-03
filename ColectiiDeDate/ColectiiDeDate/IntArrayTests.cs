using Xunit;

namespace ColectiiDeDate
{
    public class IntArrayTests
    {
        [Fact]
        public void AddAnElementToArray()
        {
            var array = new IntArray();
            array.Add(5);

            Assert.True(array.Contains(5));
        }

        [Fact]
        public void GetNumbersOfElementsFromArray()
        {
            var array = new IntArray();
            array.Add(5);
            array.Add(2);

            Assert.Equal(2, array.Count);
        }

        [Fact]
        public void ReturnTheElementFromAGivenIndex()
        {
            var array = new IntArray();
            array.Add(5);
            array.Add(2);

            Assert.Equal(2, array.Element(1));
        }

        [Fact]
        public void ChangeTheValueOfAnElement()
        {
            var array = new IntArray();
            array.Add(5);
            array.Add(2);

            array.SetElement(0, 3);

            Assert.Equal(3, array.Element(0));
        }

        [Fact]
        public void GetTheIndexOfElementReturnTheIndex()
        {
            var array = new IntArray();
            array.Add(5);
            array.Add(2);

            Assert.Equal(1, array.IndexOf(2));
        }

        [Fact]
        public void GetTheIndexOfElementReturnIndexForMissingElement()
        {
            var array = new IntArray();
            array.Add(5);
            array.Add(2);

            Assert.Equal(-1, array.IndexOf(6));
        }

        [Fact]
        public void IntroduceANewElementOnAGivenIndex()
        {
            var array = new IntArray();
            array.Add(5);
            array.Add(2);
            array.Add(3);

            array.Insert(1, 4);

            Assert.Equal(4, array.Element(1));
        }

        [Fact]
        public void RemoveAnElementFromAGivenIndex()
        {
            var array = new IntArray();
            array.Add(5);
            array.Add(2);
            array.Add(3);

            array.RemoveAt(1);

            Assert.False(array.Contains(2));
        }

        [Fact]
        public void RemoveAnElementFromAGivenIndexReturnTheLenght()
        {
            var array = new IntArray();
            array.Add(5);
            array.Add(2);

            array.RemoveAt(1);

            Assert.Equal(1, array.Count);
        }

        [Fact]
        public void RemoveAnElementFromAGivenIndexReturnTheRemainingElement()
        {
            var array = new IntArray();
            array.Add(5);
            array.Add(2);

            array.RemoveAt(1);

            Assert.True(array.Contains(5));
        }

        [Fact]
        public void RemoveFirstAparitionforAnElement()
        {
            var array = new IntArray();
            array.Add(5);
            array.Add(1);
            array.Add(2);
            array.Add(2);

            array.Remove(2);

            Assert.Equal(3, array.Count);
        }

        [Fact]
        public void RemoveFirstAparitionForElement()
        {
            var array = new IntArray();
            array.Add(5);
            array.Add(5);
            array.Add(2);

            array.Remove(5);

            Assert.Equal(1, array.IndexOf(2));
        }

        [Fact]
        public void RemoveAllElements()
        {
            var array = new IntArray();
            array.Add(5);
            array.Add(1);
            array.Add(2);
            array.Add(2);

            array.Clear();

            Assert.Equal(0, array.Count);
        }
    }
}

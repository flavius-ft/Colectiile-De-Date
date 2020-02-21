using System;
using Xunit;

namespace ColectiiDeDate
{
    public class ListTests
    {
        [Fact]
        public void AddAnElementToList()
        {
            var numbers = new List<int> { 2 };

            Assert.Equal(1, numbers.Count);
        }

        [Fact]
        public void ListContainsSpecificElement()
        {
            var numbers = new List<int> { 2, 3, 4, 5 };

            Assert.True(numbers.Contains(5));
        }

        [Fact]
        public void InsertAnElementInList()
        {
            var numbers = new List<int> { 2, 3, 5 };

            numbers.Insert(2, 4);

            Assert.Equal(4, numbers[2]);
        }

        [Fact]
        public void RemoveElementFromList()
        {
            var numbers = new List<int> { 2, 3, 4, 5 };

            numbers.Remove(3);

            Assert.Equal(4, numbers[1]);
        }

        [Fact]
        public void ExeptionForGetElementIfIndexIsGreaterThanCount()
        {
            var numbers = new List<int> { 2, 3 };
            const string message = "Elementul nu este initializat";

            try
            {
                Assert.True(numbers[2] == 3);
            }
            catch (ArgumentException exception)
            {
                Assert.Equal(message, exception.Message);
            }
        }
    }
}

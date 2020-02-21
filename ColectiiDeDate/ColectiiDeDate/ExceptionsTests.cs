using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit;

namespace ColectiiDeDate
{
    public class ExceptionsTests
    {
        [Fact]
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ExeptionForGetElementIfIndexIsGreaterThanCount()
        {
            var numbers = new List<int> { 2, 3 };

            int val = numbers[2];
        }
    }
}

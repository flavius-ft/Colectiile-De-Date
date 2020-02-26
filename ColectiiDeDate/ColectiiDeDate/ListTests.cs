﻿using System;
using Xunit;

namespace ColectiiDeDate
{
    public class ListTests
    {
        [Fact]
        public void AddAnElementToList()
        {
            var numbers = new List<int> { 2 };

            Assert.Single(numbers);
        }

        [Fact]
        public void ListContainsSpecificElement()
        {
            var numbers = new List<int> { 2, 3, 4, 5 };

            Assert.Contains(5, numbers);
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
        public void CreateACopyOfArrayFromAspecificIndex()
        {
            var numbers = new List<int> { 2, 3, 4, 5 };
            int[] secondArray = new int[numbers.Count];

            numbers.CopyTo(secondArray, 1);

            Assert.Equal(3, secondArray[0]);
            Assert.Equal(4, secondArray[1]);
            Assert.Equal(5, secondArray[2]);
        }

        [Fact]
        public void ExceptionIsReadOnly()
        {
            var numbers = new List<int> { 2, 3, 4, 5 };

            var secondArray = numbers.ListIsReadOnly();

            Assert.Throws<NotSupportedException>(() => secondArray[1] = 6);
        }

        [Fact]
        public void ExeptionForGetElementIfIndexIsGreaterThanCount()
        {
            var numbers = new List<int> { 2, 3 };

            Assert.Throws<ArgumentException>(() => numbers[2]);
        }

        [Fact]
        public void ExceptionRemoveElementFromSpecificIndex()
        {
            var numbers = new List<int> { 2, 3, 4, 5 };

            Assert.Throws<ArgumentException>(() => numbers.RemoveAt(4));
        }

        [Fact]
        public void ExceptionInsertElementToAnInvalidIndex()
        {
            var numbers = new List<int> { 2, 3, 4 };

            Assert.Throws<IndexOutOfRangeException>(() => numbers.Insert(4, 2));
        }

        [Fact]
        public void ExceptionSetElementWhenCountIs0()
        {
            var numbers = new List<int>();

            Assert.Throws<ArgumentException>(() => numbers[1] = 3);
        }

        [Fact]
        public void ExceptionNotSuportedForAddFunction()
        {
            var numbers = new List<int> { 2, 3 };

            var listIsReadOnly = numbers.ListIsReadOnly();

            Assert.Throws<NotSupportedException>(() => listIsReadOnly.Add(4));
        }
    }
}

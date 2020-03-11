using System.Collections.Generic;
using Xunit;

namespace ColectiiDeDate
{
    public class MyDictionaryTests
    {
        [Fact]
        public void AddAnElementToBucketAndCheckIfContainsTheKey()
        {
            var dictionary = new MyDictionary<int, string>(5) { { 2, "a" } };
            KeyValuePair<int, string> item = new KeyValuePair<int, string>(2, "a");

            Assert.Contains(item, dictionary);
        }

        [Fact]
        public void ContainsKeyMethodAfterAddTwoPairs()
        {
            var dictionary = new MyDictionary<int, string>(5);
            KeyValuePair<int, string> item1 = new KeyValuePair<int, string>(2, "a");
            KeyValuePair<int, string> item2 = new KeyValuePair<int, string>(7, "b");
            dictionary.Add(item1);
            dictionary.Add(item2);

            Assert.True(dictionary.ContainsKey(item2.Key));
        }
    }
}

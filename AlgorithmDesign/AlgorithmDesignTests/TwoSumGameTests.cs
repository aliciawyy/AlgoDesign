using NUnit.Framework;
using AlgorithmDesign;

namespace AlgorithmDesignTests
{
    public class TwoSumGameTests
    {
        [Test]
        public void TwoSumTest()
        {
            int start = -10000;
            int end = 10000;
            string testfile = "IntegerArray.txt";
            int expectedSumsInInterval = 9998;
            var integerArray = ReadTestFile.ReadLongIntegerArray(testfile);
            var result = TwoSumGame.TwoSum(integerArray, start, end);
            Assert.AreEqual(expectedSumsInInterval, result);
        }
    }
}
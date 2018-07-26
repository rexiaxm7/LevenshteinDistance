using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LevenshteinDistance.Tests
{
    [TestClass]
    public class LevenshteinDistanceCalculatorTest
    {
        [TestMethod]
        public void CalculateTest()
        {
            var calculate = LevenshteinDistanceCalculator.Calculate("string", "being");
            Assert.AreEqual(3, calculate);
        }
    }
}

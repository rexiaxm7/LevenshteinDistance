using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LevenshteinDistance.Tests
{
    [TestClass]
    public class LevenshteinDistanceCalculatorTest
    {
        [TestMethod]
        public void CalculateTest()
        {
            var distance = LevenshteinDistanceCalculator.Calculate("string", "being");
            Assert.AreEqual(3, distance);
        }

        [TestMethod]
        public void CalculateWithCostTest()
        {
            var distance = LevenshteinDistanceCalculator.Calculate("agent", "agency", 7, 10, 7);
            Assert.AreEqual(17, distance);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsFleetManagement.Domain.Models;

namespace StarWarsFleetManagement.Tests
{
    [TestClass]
    public class StarshipsDomainTests
    {
        [DataTestMethod]
        [DataRow("40", "6 years", 1000000, "0")]
        [DataRow("70", "1 month", 1000000, "19")]
        [DataRow("80", "1 week", 1000000, "74")]
        [DataRow("unknown", "6 years", 1000000, "unknown")]
        [DataRow("70", "6 xpti", 1000000, "unknown")]
        [DataRow("40", "6 years", 25145232, "11")]
        public void CalculateResupplyCorrect(string mglt, string consumables, long mgltInput, string result)
        {
            Assert.AreEqual(new Starship(mglt, consumables, "").CalculateAmountStopsRequired(mgltInput), result);
        }
    }
}

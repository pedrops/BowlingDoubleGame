using BowlingGame.BL.Services;
using BowlingGame.DA.Interfaces;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace BowlingGame.BL.Tests.Services
{
    public class BowlingCacheProviderTests
    {

        [Test]
        [TestCase("/")]
        [TestCase("3")]
        [TestCase( "X")]
        public void GetScore_ForcedResults_ResultCalculation(string result)
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.SetupAllProperties();

            mockUnitOfWork.Setup(x => x.GetScore(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(result));

            BowlingCacheProvider bowlingCacheProvider = new BowlingCacheProvider(mockUnitOfWork.Object);
            var score = bowlingCacheProvider.getScore(1, 1);
            Assert.AreEqual(score.Result, result);
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {}
    }
}

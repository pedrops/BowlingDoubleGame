using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Moq;
using BowlingGame.BL.Services;
using BowlingGame.DA.Interfaces;
using BowlingGame.BL.Interfaces;
using System.Threading;

namespace BowlingGame.BL.Tests.Services
{
    public class BowlingCacheTests
    {
        [Test]
        [TestCase("1","/")]
        [TestCase("1", "3")]
        [TestCase("1", "X")]
        public void GetScore_AttemptsResults_DecidesBasedOnCache(string firstAttempt, string result)
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.SetupAllProperties();
            mockUnitOfWork.Setup(x => x.GetScore(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(firstAttempt));
            var mockBowlingCacheProviderCached = new BowlingCacheProvider(mockUnitOfWork.Object);

            var mockBowlingCacheProvider = new Mock<IBowlingCacheProvider>();
            mockBowlingCacheProvider.SetupAllProperties();

            mockBowlingCacheProvider.Setup(x => x.getScore(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(result));

            BowlingCache bowlingCache = new BowlingCache(mockBowlingCacheProvider.Object);
            

            var score = bowlingCache.getScore(1, 1);
            Assert.AreEqual(score.Result, result);


            // this is forcing cache to be filled
            // this is on time will be calling from cash, forcing a non expected result
            bowlingCache = new BowlingCache(mockBowlingCacheProvider.Object)
            {
                LastUpdated = DateTime.Now,
                UserScore = firstAttempt
            };
            score = bowlingCache.getScore(1, 1);
            Assert.AreNotEqual(score.Result, result);

            // wait to check passed 5 seconds according general rule
            // must call to real data
            Thread.Sleep(6 * 1000);

            score = bowlingCache.getScore(1, 1);
            Assert.AreEqual(score.Result, result);
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {}
    }
}

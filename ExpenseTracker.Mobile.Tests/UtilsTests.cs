using System;
using System.Linq;
using ExpenseTracker.Mobile.Services;
using ExpenseTracker.Mobile.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ExpenseTracker.Mobile.Tests
{
    [TestClass]
    public class UtilsTests
    {
        [TestMethod]
        public void GetWeek_WhenInvoked_ShouldReturnCurrentWeek()
        {
            //arrange
            var dateTimeService = new Mock<IDateTimeService>();
            dateTimeService.SetupSequence(x => x.UtcNow)
                .Returns(new DateTime(2019, 3, 4)) //monday
                .Returns(new DateTime(2019, 3, 5))
                .Returns(new DateTime(2019, 3, 6))
                .Returns(new DateTime(2019, 3, 7))
                .Returns(new DateTime(2019, 3, 8))
                .Returns(new DateTime(2019, 3, 9))
                .Returns(new DateTime(2019, 3, 10)); //sunday


            for (int i = 0; i < 7; ++i)
            {
                //act
                var week = DateTimeUtils.GetCurrentWeek(dateTimeService.Object);

                //assert
                Assert.AreEqual(7, week.Count());
                Assert.AreEqual(DayOfWeek.Monday, week.First().DayOfWeek);
                Assert.AreEqual(DayOfWeek.Sunday, week.Last().DayOfWeek);
            }
        }
    }
}

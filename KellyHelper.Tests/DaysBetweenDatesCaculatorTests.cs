using System;
using System.Collections.Generic;
using Kenbo.KellyHelper.Helpers.DateRangeCalculator;
using Xunit;

namespace Kenbo.KellyHelper.Tests
{
    public class DaysBetweenDatesCaculatorTests
    {
        [Theory]
        [MemberData(nameof(DatesAndExpectedDays))]
        public void Calculate_correct_number_of_days(DateTime first, DateTime second, int expectedDays)
        {
            var calculatedDays = DaysBetweenDatesCalculator.CalculateDays(first, second);
            Assert.Equal(expectedDays, calculatedDays);
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static IEnumerable<object[]> DatesAndExpectedDays => new[]
        {
            new object[] {new DateTime(2016, 1, 1), new DateTime(2016, 2, 1), 31},
            new object[] {new DateTime(2016, 2, 1), new DateTime(2016, 1, 1), 31},
            new object[] {new DateTime(2016, 1, 1), new DateTime(2017, 1, 1), 366},
            new object[] {new DateTime(2016, 1, 5), new DateTime(2016, 1, 31), 26},
            new object[] {new DateTime(2015, 1, 1), new DateTime(2017, 1, 1), 731},
            new object[] {new DateTime(2016, 7, 18), new DateTime(2016, 9, 13), 57},
            new object[] {new DateTime(2016, 1, 13), new DateTime(2016, 11, 2), 294},
        };
    }
}
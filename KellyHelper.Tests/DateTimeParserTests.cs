using System;
using System.Collections.Generic;
using Kenbo.KellyHelper.Helpers.HelperClasses;
using Xunit;

namespace Kenbo.KellyHelper.Tests
{
    public class DateTimeParserTests
    {
        [Theory]
        [MemberData(nameof(Dates))]
        public void Parse_date_correctly(string textDate, DateTime expectedDate)
        {
            var convertedDate = DateTimeParser.ConvertToDate(textDate);
            Assert.True(convertedDate.Item1);
            Assert.Equal(expectedDate, convertedDate.Item2);
        }

        public static IEnumerable<object[]> Dates => new[]
        {
            new object[] {"1/1/2016", new DateTime(2016, 1, 1)},
            new object[] {"5-10-2016", new DateTime(2016, 10, 5)},
        };

        [Fact]
        public void Parse_incorrect_date()
        {
            var convertedDate = DateTimeParser.ConvertToDate("not a date");
            Assert.False(convertedDate.Item1);
            Assert.Equal(DateTime.MinValue, convertedDate.Item2);
        }
    }
}
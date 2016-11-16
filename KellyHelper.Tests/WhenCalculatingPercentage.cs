﻿using System.IO;
using FakeItEasy;
using Kenbo.KellyHelper.Helpers.PercentCalculatorHelper;
using Xunit;
using Shouldly;


namespace Kenbo.KellyHelper.Tests
{
    public class WhenCalculatingPercentage
    {
        private readonly PercentCalculatorHelper _calculator;

        public WhenCalculatingPercentage()
        {
            var textReader = A.Fake<TextReader>();
            var textWriter = A.Fake<TextWriter>();
            _calculator = new PercentCalculatorHelper(textReader, textWriter);
        }

        [Theory]
        [InlineData(100, 200, 50.00)]
        [InlineData(5, 200, 2.50)]
        [InlineData(1.8, 199.54, .9)]
        [InlineData(21.24, 2565.82, 0.82)]
        public void CalculatePercentage(double value, double total, double result)
        {
            var percentage = _calculator.CalculatePercentage(value, total);
            percentage.ShouldBe(result, 2);
        }
    }
}

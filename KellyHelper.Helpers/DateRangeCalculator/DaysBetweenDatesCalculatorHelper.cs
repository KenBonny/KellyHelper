using System;
using System.IO;

namespace Kenbo.KellyHelper.Helpers.DateRangeCalculator
{
    public class DaysBetweenDatesCalculatorHelper : Helper
    {
        public DaysBetweenDatesCalculatorHelper(TextReader reader, TextWriter writer) : base(reader, writer)
        {
        }

        public override string Description => "Calculate the number of days between two dates.";

        public override void Run()
        {
            var firstDate = GetValue<DateTime>("First date: ");
            var secondDate = GetValue<DateTime>("Second date: ");
            
            var days = DaysBetweenDatesCalculator.CalculateDays(firstDate, secondDate);
            Writer.WriteLine($"Days between dates: {days}");
        }
    }
}
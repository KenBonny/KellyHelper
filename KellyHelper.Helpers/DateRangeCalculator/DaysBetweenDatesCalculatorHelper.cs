using System;
using System.IO;
using Kenbo.KellyHelper.Helpers.HelperClasses;

namespace Kenbo.KellyHelper.Helpers.DateRangeCalculator
{
    public class DaysBetweenDatesCalculatorHelper : IHelper
    {
        public string Description => "Calculates the number of days between two dates.";

        public void Run(TextWriter writer, TextReader reader)
        {
            var firstDate = GetDate(writer, reader, "First date: ");
            var secondDate = GetDate(writer, reader, "Second date: ");
            
            var caluclator = new DaysBetweenDatesCalculator();
            var days = caluclator.CalculateDays(firstDate, secondDate);
            writer.WriteLine($"Days between dates: {days}");
        }

        private DateTime GetDate(TextWriter writer, TextReader reader, string message)
        {
            Tuple<bool, DateTime> date;
            do
            {
                writer.Write(message);
                var line = reader.ReadLine();
                date = DateTimeParser.ConvertToDate(line);
                if (!date.Item1)
                {
                    writer.WriteLine("Invalid date format.");
                }
            } while (!date.Item1);

            return date.Item2;
        }
    }
}
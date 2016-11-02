using System.IO;

namespace Kenbo.KellyHelper.Helpers.PercentCalculatorHelper
{
    public class PercentCalculatorHelper : IHelper
    {
        public string Description
        {
            get { return "Calculate a percentage"; }
        }

        public void Run(TextWriter writer, TextReader reader)
        {
            var value = GetValue(writer, reader, "Calculate percentage for");
            var total = GetValue(writer, reader, "From total");
            var percent = CalculatePercentage(value, total);
            writer.WriteLine($"Is {percent:F2}%");
        }

        public double CalculatePercentage(double value, double total)
        {
            return value/total*100;
        }

        private static double GetValue(TextWriter writer, TextReader reader, string text)
        {
            double value = 0;
            bool invalidInteger;
            do
            {
                writer.Write($"{text}: ");
                var line = reader.ReadLine();
                invalidInteger = string.IsNullOrWhiteSpace(line) || !double.TryParse(line, out value);
            } while (invalidInteger);

            return value;
        }
    }
}
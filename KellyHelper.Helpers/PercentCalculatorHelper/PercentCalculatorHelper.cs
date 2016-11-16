using System.IO;

namespace Kenbo.KellyHelper.Helpers.PercentCalculatorHelper
{
    public class PercentCalculatorHelper : Helper
    {
        public PercentCalculatorHelper(TextReader reader, TextWriter writer) : base(reader, writer)
        {
        }

        public override string Description => "Calculate a percentage";

        public override void Run()
        {
            var value = GetValue<double>("Calculate percentage for ");
            var total = GetValue<double>("From total ");
            var percent = CalculatePercentage(value, total);
            Writer.WriteLine($"Is {percent:F2}%");
        }

        public double CalculatePercentage(double value, double total)
        {
            return value/total*100;
        }
    }
}
using System.IO;

namespace Kenbo.KellyHelper.Console.PercentCalculatorHelper
{
    internal class PercentCalculator : IHelper
    {
        public string Description
        {
            get { return "Calculate a percentage"; }
        }

        public void Run(TextWriter writer, TextReader reader)
        {
            writer.WriteLine(GetType().Name);
        }
    }
}
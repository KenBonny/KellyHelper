using System;
using System.Collections.Generic;
using Autofac;

namespace Kenbo.KellyHelper.Console
{
    public class Program
    {
        static void Main()
        {
            var helpers = GetHelpers();
            while (true)
            {
                PrintChoice(helpers);
                var position = GetPosition(helpers.Count);
                if (position == 0) break;
                RunHelper(helpers[position]);
            }
        }

        private static void PrintChoice(IDictionary<int, IHelper> helpers)
        {
            System.Console.WriteLine("Please choose the help you need:");
            foreach (var helper in helpers)
            {
                System.Console.WriteLine($" {helper.Key} > {helper.Value.Description}");
            }

            System.Console.WriteLine(" 0 > Exit");
        }

        private static void RunHelper(IHelper helper)
        {
            bool runAgain;
            do
            {
                helper.Run(System.Console.Out, System.Console.In);
                System.Console.Write("Back to main screen? (Yes or No, default No) ");
                var line = System.Console.ReadLine();
                runAgain = string.IsNullOrWhiteSpace(line) ||
                           line.Equals("y", StringComparison.InvariantCultureIgnoreCase) ||
                           line.Equals("yes", StringComparison.InvariantCultureIgnoreCase);
            } while (runAgain);
        }

        private static int GetPosition(int max)
        {
            var position = 1;
            bool invalidInteger;
            do
            {
                System.Console.Write("Choose helper: ");
                var line = System.Console.ReadLine();
                invalidInteger = string.IsNullOrWhiteSpace(line) || !int.TryParse(line, out position);
            } while (invalidInteger || position > max);

            return position;
        }

        private static IDictionary<int, IHelper> GetHelpers()
        {
            var helpers = Setup.CreateContainer().Resolve<IEnumerable<IHelper>>();
            var position = 1;
            var dictionary = new Dictionary<int, IHelper>();
            foreach (var helper in helpers)
            {
                dictionary.Add(position, helper);
                position++;
            }

            return dictionary;
        }  
    }
}
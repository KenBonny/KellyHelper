using System;
using System.Collections.Generic;
using Autofac;
using Kenbo.KellyHelper.Helpers;

namespace Kenbo.KellyHelper.UI
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

        private static void PrintChoice(IDictionary<int, IHelper> helpers)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please choose the help you need:");
            foreach (var helper in helpers)
            {
                Console.WriteLine($" {helper.Key} > {helper.Value.Description}");
            }

            Console.WriteLine(" 0 > Exit");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static int GetPosition(int max)
        {
            var position = 1;
            bool invalidInteger;
            do
            {
                Console.Write("Choose helper: ");
                var line = Console.ReadLine();
                invalidInteger = string.IsNullOrWhiteSpace(line) || !int.TryParse(line, out position);
            } while (invalidInteger || position > max);
            Console.WriteLine();

            return position;
        } 

        private static void RunHelper(IHelper helper)
        {
            bool runAgain;
            do
            {

                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(helper.Description);
                    Console.WriteLine(new string('-', helper.Description.Length));
                    Console.ForegroundColor = ConsoleColor.Gray;

                    helper.Run(Console.Out, Console.In);
                }
                catch (Exception exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(exception.Message);
                    var inner = exception.InnerException;
                    while (inner != null)
                    {
                        Console.WriteLine($" > {inner.Message}");
                        Console.WriteLine();
                        inner = inner.InnerException;
                    }

                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                finally
                {
                    Console.Write("Run again? (Yes or No, default Yes) ");
                    var line = Console.ReadLine();
                    Console.WriteLine();

                    runAgain = string.IsNullOrWhiteSpace(line) ||
                               line.Equals("y", StringComparison.InvariantCultureIgnoreCase) ||
                               line.Equals("yes", StringComparison.InvariantCultureIgnoreCase);
                }
            } while (runAgain);
        }
    }
}
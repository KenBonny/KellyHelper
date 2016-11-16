using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Builder;
using Kenbo.KellyHelper.Helpers;

namespace Kenbo.KellyHelper.UI
{
    public class Program
    {
        public static void Main()
        {
            var helpers = GetHelpers();
            while (true)
            {
                PrintChoice(helpers);
                var position = GetPosition(helpers.Count);
                if (position == 0)
                    break;
                RunHelper(helpers[position]);
            }
        }

        private static IDictionary<int, Helper> GetHelpers()
        {
            var helpers = Setup.CreateContainer().Resolve<IEnumerable<Helper>>();
            var position = 1;
            var dictionary = new Dictionary<int, Helper>();
            foreach (var helper in helpers)
            {
                dictionary.Add(position, helper);
                position++;
            }

            return dictionary;
        } 

        private static void PrintChoice(IDictionary<int, Helper> helpers)
        {
            const ConsoleColor green = ConsoleColor.Green;
            WriteLineInColor("Please choose the help you need:", green);
            WriteLineInColor(" 0 > Exit", green);

            foreach (var helper in helpers)
            {
                var message = $" {helper.Key} > {helper.Value.Description}";
                WriteLineInColor(message, green);
            }
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

        private static void RunHelper(Helper helper)
        {
            bool runAgain;
            do
            {

                try
                {
                    WriteLineInColor(helper.Description, ConsoleColor.White);
                    WriteLineInColor(new string('-', helper.Description.Length), ConsoleColor.White);
                    helper.Run();
                }
                catch (Exception exception)
                {
                    const ConsoleColor red = ConsoleColor.Red;
                    WriteLineInColor(exception.Message, red);

                    var inner = exception.InnerException;
                    while (inner != null)
                    {
                        WriteLineInColor($" > {inner.Message}", red);
                        Console.WriteLine();
                        inner = inner.InnerException;
                    }
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

        private static void WriteLineInColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
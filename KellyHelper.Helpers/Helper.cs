using System;
using System.ComponentModel;
using System.IO;

namespace Kenbo.KellyHelper.Helpers
{
    public abstract class Helper
    {
        protected readonly TextWriter Writer;
        protected readonly TextReader Reader;

        protected Helper(TextReader reader, TextWriter writer)
        {
            Writer = writer;
            Reader = reader;
        }

        public abstract string Description { get; }
        public abstract void Run();

        protected virtual T GetValue<T>(string message)
        {
            T value;
            bool invalidValue;

            do
            {
                Writer.Write(message);
                var line = Reader.ReadLine();
                invalidValue = !TryParse(line, out value);
            } while (invalidValue);

            return value;
        }

        private static bool TryParse<T>(string line, out T value)
        {
            try
            {
                value = (T) TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(line);
                return true;
            }
            catch(Exception)
            {
                value = default(T);
                return false;
            }
        }
    }
}
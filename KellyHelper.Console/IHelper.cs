using System.IO;

namespace Kenbo.KellyHelper.Console
{
    internal interface IHelper
    {
        string Description { get; }

        void Run(TextWriter writer, TextReader reader);
    }
}
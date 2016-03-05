using System.IO;

namespace Kenbo.KellyHelper.UI
{
    internal interface IHelper
    {
        string Description { get; }

        void Run(TextWriter writer, TextReader reader);
    }
}
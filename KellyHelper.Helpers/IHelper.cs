using System.IO;

namespace Kenbo.KellyHelper.Helpers
{
    public interface IHelper
    {
        string Description { get; }

        void Run(TextWriter writer, TextReader reader);
    }
}
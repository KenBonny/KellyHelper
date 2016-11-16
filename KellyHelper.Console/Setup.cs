using System;
using System.IO;
using Autofac;
using Kenbo.KellyHelper.Helpers;

namespace Kenbo.KellyHelper.UI
{
    internal class Setup
    {
        internal static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(Console.In).As<TextReader>();
            builder.RegisterInstance(Console.Out).As<TextWriter>();

            builder.RegisterAssemblyTypes(typeof(Helper).Assembly)
                .Where(type => type.IsSubclassOf(typeof(Helper)))
                .As<Helper>();

            return builder.Build();
        }
    }
}
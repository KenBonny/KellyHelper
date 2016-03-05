using Autofac;
using Kenbo.KellyHelper.Console.PercentCalculatorHelper;

namespace Kenbo.KellyHelper.Console
{
    internal class Setup
    {
        internal static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<PercentCalculator>().AsImplementedInterfaces();

            return builder.Build();
        }
    }
}
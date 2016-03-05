using Autofac;
using Kenbo.KellyHelper.UI.PercentCalculatorHelper;

namespace Kenbo.KellyHelper.UI
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
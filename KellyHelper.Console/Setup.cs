using Autofac;
using Kenbo.KellyHelper.Helpers.DateRangeCalculator;
using Kenbo.KellyHelper.Helpers.PercentCalculatorHelper;

namespace Kenbo.KellyHelper.UI
{
    internal class Setup
    {
        internal static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<PercentCalculatorHelper>().AsImplementedInterfaces();
            builder.RegisterType<DaysBetweenDatesCalculatorHelper>().AsImplementedInterfaces();

            return builder.Build();
        }
    }
}
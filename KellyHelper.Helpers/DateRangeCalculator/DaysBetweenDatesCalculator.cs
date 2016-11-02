using System;

namespace Kenbo.KellyHelper.Helpers.DateRangeCalculator
{
    public class DaysBetweenDatesCalculator
    {
        public int CalculateDays(DateTime first, DateTime second)
        {
            var days = (second - first).Days;

            if (days < 0)
            {
                days *= -1;
            }

            return days;
        }
    }
}
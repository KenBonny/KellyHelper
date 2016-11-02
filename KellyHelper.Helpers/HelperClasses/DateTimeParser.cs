using System;

namespace Kenbo.KellyHelper.Helpers.HelperClasses
{
    public static class DateTimeParser
    {
        public static Tuple<bool, DateTime> ConvertToDate(string date)
        {
            DateTime actualDate;
            var parsedSuccessfully = DateTime.TryParse(date, out actualDate);
            return new Tuple<bool, DateTime>(parsedSuccessfully, actualDate);
        }
    }
}
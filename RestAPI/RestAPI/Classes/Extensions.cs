using System.Globalization;

namespace RestAPI.Classes
{
    public static class Extensions
    {
        public static decimal ToDecimal(this string input, decimal defaultValue = 0m)
        {
            if (string.IsNullOrWhiteSpace(input))
                return defaultValue;

            if (decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
                return result;

            return defaultValue;
        }
    }
}

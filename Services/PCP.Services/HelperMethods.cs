using System.Globalization;
using System.Text.RegularExpressions;

namespace PCP.Services
{
    public class HelperMethods
    {
        private readonly Regex matchOneOrMoreDigits;
        private readonly Regex matchOneOrMoreDigitsWithFloat;

        public HelperMethods()
        {
            this.matchOneOrMoreDigits = new Regex(@"\d+");
            this.matchOneOrMoreDigitsWithFloat = new Regex(@"\d+\.?\d?");
        }

        public short GetFrecuencyAsShort(string frequencyAsString)
        {
            if (frequencyAsString.Contains("Boost"))
            {
                frequencyAsString = frequencyAsString.Replace("Intel Turbo Boost 2.0 Max Technology Frequency:", string.Empty);
            }

            var match = this.matchOneOrMoreDigitsWithFloat.Match(frequencyAsString);
            var value = match.Value;
            var floatResult = float.Parse(value, CultureInfo.InvariantCulture);
            var isInGigahertz = frequencyAsString.ToLower().Contains("ghz");
            if (isInGigahertz)
            {
                floatResult *= 1000;
            }

            var result = (short)floatResult;
            return result;
        }
    }
}

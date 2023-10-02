namespace CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Infrastructure.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static string RoundToDecimalString(this string input)
        {
            if (decimal.TryParse(input, out decimal number))
            {
                int roundedNumber = (int)Math.Round(number, MidpointRounding.AwayFromZero);
                return roundedNumber.ToString();
            }
            else
            {
                throw new ArgumentException("The entry is not a valid number.");
            }
        }
    }
}

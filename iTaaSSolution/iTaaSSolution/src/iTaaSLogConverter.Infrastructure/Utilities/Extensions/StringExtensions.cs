namespace CandidateTesting.OswaldoDaSilvaNicacioJunior.src.iTaaSLogConverter.Infrastructure.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static string RoundToDecimalString(this string input)
        {
            if (decimal.TryParse(input, out decimal number))
            {
                decimal roundedNumber = Math.Round(number, 0);
                return roundedNumber.ToString($"0.{new string('0', 0)}");
            }
            else
            {
                throw new ArgumentException("The entry is not a valid number.");
            }
        }
    }
}

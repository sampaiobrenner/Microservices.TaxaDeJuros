using System.Globalization;

namespace Microservices.TaxaDeJuros.WebApi.IntegrationTests.Extensions
{
    public static class StringExtensions
    {
        public static decimal ParseDecimal(this string valor)
        {
            var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            return decimal.Parse(valor, style, CultureInfo.InvariantCulture);
        }
    }
}
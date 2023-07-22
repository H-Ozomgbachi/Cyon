using System.Text;

namespace Cyon.Infrastructure.Helpers
{
    public class GeneralHelpers
    {
        private const string _charSet = "0123456789CYONSH";
        private static readonly Random _random = new();

        public static string GeneratePasscode()
        {
            StringBuilder couponCode = new(8);
            for (int i = 0; i < 8; i++)
            {
                couponCode.Append(_charSet[_random.Next(_charSet.Length)]);
            }
            return couponCode.ToString();
        }
    }
}

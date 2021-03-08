using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApi
{
    public class AuthOptions
    {
        public const string ISSUER = "MoneyWallet";
        public const string AUDIENCE = "MoneyWalletClient";
        const string KEY = "secretkey";
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}

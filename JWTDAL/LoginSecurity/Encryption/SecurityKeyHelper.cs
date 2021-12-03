using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JWTDAL.LoginSecurity.Encryption
{
    //Microsoft.IdentityModel.Tokens => using library for Security Key
    public static class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}

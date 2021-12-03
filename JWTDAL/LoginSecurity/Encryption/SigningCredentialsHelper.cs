using Microsoft.IdentityModel.Tokens;

namespace JWTDAL.LoginSecurity.Encryption
{
    public static class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
        }
    }
}

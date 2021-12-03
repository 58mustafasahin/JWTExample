namespace JWTDAL.LoginSecurity.Entity
{
    //The properties created to send the user's information in the JWT payload section.
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}

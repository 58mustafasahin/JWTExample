using System;

namespace JWTDAL.LoginSecurity.Entity
{
    /// <summary>
    /// jwt to use Frontend
    /// </summary>
    public class AccessToken 
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}

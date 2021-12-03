using System.Collections.Generic;
using System.Security.Claims;

namespace JWTDAL.LoginSecurity.Extension
{
    public static class RoleExtension
    {
        public static void AddUserIdentifier(this ICollection<Claim> claims, int id)
        {
            claims.Add(new Claim(PayloadRoleIdentifier.UserIdentifier, id.ToString()));
        }

        public static void AddFullName(this ICollection<Claim> claims, string fullName)
        {
            claims.Add(new Claim(PayloadRoleIdentifier.FullName, fullName));
        }

        public static void AddRole(this ICollection<Claim> claims, IEnumerable<string> roles)
        {
            foreach (var item in roles) claims.Add(new Claim(PayloadRoleIdentifier.Role, item));
        }
    }
}

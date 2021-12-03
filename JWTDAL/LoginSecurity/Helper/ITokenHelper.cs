using JWTDAL.Entity;
using JWTDAL.LoginSecurity.Entity;
using System.Collections.Generic;

namespace JWTDAL.LoginSecurity.Helper
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, IEnumerable<Role> userRoles);
    }
}

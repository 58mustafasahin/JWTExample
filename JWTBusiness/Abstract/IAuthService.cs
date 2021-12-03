using JWTDAL.Entity;
using JWTDAL.Entity.Dto;
using JWTDAL.LoginSecurity.Entity;
using System.Threading.Tasks;

namespace JWTBusiness.Abstract
{
    public interface IAuthService
    {
        Task<AccessToken> CreateAccessTokenAsync(User user);
        Task<User> GetLoginUserAsync(UserLoginDto userLoginDto);
        Task<int> RegisterAsync(UserRegisterDto userRegisterDto);
    }
}
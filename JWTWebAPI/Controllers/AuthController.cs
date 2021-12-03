using JWTBusiness.Abstract;
using JWTDAL.Entity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JWTWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(UserRegisterDto userRegisterDto)
        {
            var registerResult = await _authService.RegisterAsync(userRegisterDto);
            if (registerResult > 0)
            {
                return Ok(new { code = StatusCode(1000), message= "User registration successful", type="success"});
            }
            return Ok(new { code = StatusCode(1001), message = "User registration failed", type = "error" });

        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(UserLoginDto userLoginDto)
        {
            var currentUser = await _authService.GetLoginUserAsync(userLoginDto);

            if (currentUser == null)
            {
                Ok(new { code = StatusCode(1001), message = "User not found", type = "error" });
            }
            else if (currentUser.Surname == null)
            {
                Ok(new { code = StatusCode(1001), message = "Username or password is incorrect", type = "error" });
            }
            var accessToken = await _authService.CreateAccessTokenAsync(currentUser);
            return Ok(accessToken);
        }

        [Authorize]
        [HttpGet]
        [Route("GetUserName")]
        public ActionResult GetUserName()
        {
            return Ok("name is here");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetName")]
        public ActionResult GetName()
        {
            return Ok("User role name");
        }
    }
}

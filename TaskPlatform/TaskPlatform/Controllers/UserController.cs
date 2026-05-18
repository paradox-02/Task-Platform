using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskPlatform.Common;
using TaskPlatform.DTOs.User;
using TaskPlatform.Services;

namespace TaskPlatform.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Create(UserCreateDto dto)
        {
            var result = _userService.CreateUser(dto.Username, dto.Password);
            return Ok(ApiResponse<object>.Success(result, "创建成功"));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("GetUsers")]
        public async Task<IActionResult> GetUsers(UserQueryDto dto)
        {
            var users = await _userService.GetUsers(dto);
            return Ok(ApiResponse<object>.Success(users));
        }

        [HttpPost("Login")]
        public IActionResult Login(UserLoginDto dto, [FromServices] JwtService jwtService)
        {
            if (dto.Username != "admin" || dto.Password != "123456")
            {
                return BadRequest("账号或密码错误！");
            }

            var token = jwtService.GenerateToken(1, dto.Username);

            return Ok(ApiResponse<object>.Success(new
            {
                Token = token
            }));
        }
    }
}

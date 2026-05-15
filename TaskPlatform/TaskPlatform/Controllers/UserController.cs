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

        [HttpGet]
        public async Task<IActionResult> Get(UserQueryDto dto)
        {
            var users = await _userService.GetUsers(dto);
            return Ok(ApiResponse<object>.Success(users));
        }
    }
}

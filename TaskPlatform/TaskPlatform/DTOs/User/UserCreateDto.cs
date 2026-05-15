using System.ComponentModel.DataAnnotations;

namespace TaskPlatform.DTOs.User
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "用户名不能为空")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "密码不能为空")]
        [MinLength(6, ErrorMessage = "密码长度不能小于6位")]
        public string Password { get; set; } = string.Empty;
    }
}

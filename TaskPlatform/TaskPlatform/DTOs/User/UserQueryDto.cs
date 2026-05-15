using TaskPlatform.Common;

namespace TaskPlatform.DTOs.User
{
    public class UserQueryDto : PageQueryDto
    {
        public string? Keyword { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}

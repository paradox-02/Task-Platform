using AutoMapper;
using TaskPlatform.DTOs.User;
using TaskPlatform.Models;

namespace TaskPlatform.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponseDto>();
        }
    }
}

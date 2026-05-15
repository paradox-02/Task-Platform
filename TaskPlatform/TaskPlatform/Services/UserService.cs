using Microsoft.EntityFrameworkCore;
using TaskPlatform.Data;
using TaskPlatform.Models;
using TaskPlatform.Extensions;
using TaskPlatform.Common;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskPlatform.DTOs.User;
using AutoMapper;

namespace TaskPlatform.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> CreateUser(string username, string password)
        {
            var user = new User
            {
                Username = username,
                Password = password,
                CreateTime = DateTime.Now
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<PagedResult<UserResponseDto>> GetUsers(UserQueryDto dto)
        {
            var query = _context.Users.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(dto.Keyword))
                query = query.Where(n => n.Username.Contains(dto.Keyword));

            if (dto.StartTime.HasValue)
                query = query.Where(n => n.CreateTime >= dto.StartTime.Value);

            if (dto.EndTime.HasValue)
                query = query.Where(n => n.CreateTime <= dto.EndTime.Value);

            var paged = await query.OrderByDescending(n => n.Id).ToPagedAsync(dto.PageIndex, dto.PageSize);

            return new PagedResult<UserResponseDto>
            {
                Total = paged.Total,
                Items = _mapper.Map<List<UserResponseDto>>(paged.Items)
            };
        }
    }
}

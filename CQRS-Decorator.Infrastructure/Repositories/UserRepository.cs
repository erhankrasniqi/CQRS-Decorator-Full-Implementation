using Microsoft.EntityFrameworkCore;
using CQRS_Decorator.Domain.Entities;
using CQRS_Decorator.Domain.Interfaces;
using CQRS_Decorator.Infrastructure.Data;

namespace CQRS_Decorator.Infrastructure.Repositories
{
      
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }

}

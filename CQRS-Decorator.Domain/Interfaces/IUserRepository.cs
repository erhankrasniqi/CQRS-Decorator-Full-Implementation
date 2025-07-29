using CQRS_Decorator.Domain.Aggregates.UserAggregate;

namespace CQRS_Decorator.Domain.Interfaces
{


    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}

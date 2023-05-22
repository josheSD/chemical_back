using chemical.back.Domain.Entities;

namespace chemical.back.Interface.Persistence
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<bool> AddSync(User user);

        Task<bool> UpdateAsync(User user);

        Task<bool> RemoveAsync(User user);
    }
}

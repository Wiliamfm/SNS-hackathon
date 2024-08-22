using sns.application.Interfaces.Persistence;
using sns.domain.Entities;

namespace Sns.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    public Task AddAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}

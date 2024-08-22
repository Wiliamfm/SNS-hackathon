using Microsoft.EntityFrameworkCore;
using sns.application.Interfaces.Persistence;
using sns.domain.Entities;

namespace Sns.Infrastructure.Persistence;

public class UserRepository(AppDbContext dbContext) : IUserRepository
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
        return dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}

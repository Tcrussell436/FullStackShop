using FullStackShop.Domain.Interfaces;

namespace FullStackShop.Domain.Models.Repositories;

public interface IUserRepository : IRepository<User>
{
    User Add(User user);
    Task<User?> GetAsync(string userId);
    void Update(User user);
}
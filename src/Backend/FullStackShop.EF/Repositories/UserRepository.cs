using FullStackShop.Domain.Interfaces;
using FullStackShop.Domain.Models;
using FullStackShop.Domain.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FullStackShop.EF.Repositories;

public class UserRepository : IUserRepository
{
    public IUnitOfWork UnitOfWork => _context;
    
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }


    public User Add(User user)
    {
        return _context.Users.Add(user).Entity;
    }

    public async Task<User?> GetAsync(string userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null) return user;
        
        // add additional nav props

        return user;
    }

    public void Update(User user)
    {
        throw new NotImplementedException();
    }
}
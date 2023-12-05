using Microsoft.AspNetCore.Identity;

namespace FullStackShop.Domain.Models;

/// <summary>
/// Override IdentityUser class to add properties
/// </summary>
public class User : IdentityUser
{
    
    public User() : base()
    { }
    
    public User(string userName) : base(userName)
    { }
}
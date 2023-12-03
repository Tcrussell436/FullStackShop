using System.ComponentModel.DataAnnotations;

namespace FullStackShop.Domain.Models;

public class User
{
    [MaxLength(256)]
    private string _id;
    [MaxLength(64)]
    private string _email;
 
    
    public string Id => _id;
    public string Email => _email;
    public DateTime CreatedOn { get; init; }

    
    // Ctor
    protected User()
    {
        _id = string.Empty;
        _email = string.Empty;
    }
    
    public User(string id, string email)
    {
        _id = id;
        _email = email;
    }

    
    public void SetEmail(string email)
    {
        _email = email;
    }
}
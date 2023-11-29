using System.ComponentModel.DataAnnotations;

namespace FullStackShop.Domain.Models;

public class User
{
    public string Id => _id;
    public string Email => _email;
    public DateTime CreatedOn { get; init; }

    [MaxLength(256)]
    private string _id;
    [MaxLength(64)]
    private string _email;

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

    public void UpdateEmail(string email)
    {
        _email = email;
    }
}
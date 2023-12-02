using System.ComponentModel.DataAnnotations;

namespace FullStackShop.Domain.Models;

public class Product
{
    // Properties
    public int Id { get; private set; }
    public string Name => _name;
    public string? Description => _description;
    public decimal? Price => _price;
    public ProductCategory? Category => _category;

    // Fields
    [Required]
    [MaxLength(64)]
    private string _name;
    [MaxLength(2048)]
    private string? _description;
    private decimal? _price;
    private int _categoryId;
    private ProductCategory? _category;


    // Constructors
    protected Product()
    {
        _name = string.Empty;
    }
    
    public Product(string name, int categoryId, string? description = null,
        decimal? price = null)
    {
        _name = name;
        _categoryId = categoryId;
        _description = description;
        _price = price;
    }

    
    public void UpdateCategory(ProductCategory category)
    {
        _category = category;
    }

    public void UpdateName(string name)
    {
        _name = name;
    }

    public void UpdateDescription(string description)
    {
        _description = description;
    }

    public void UpdatePrice(decimal? price)
    {
        _price = price;
    }
}

public class ProductCategory
{
    public int Id { get; init; }
    public string Name => _name;
    
    [MaxLength(32)]
    private string _name;

    
    protected ProductCategory()
    {
        _name = string.Empty;
    }
    public ProductCategory(string name)
    {
        _name = name;
    }

    
    public void SetName(string newName)
    {
        _name = newName;
    }
}
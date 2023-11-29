using System.Collections.Immutable;
using FullStackShop.Domain.Interfaces;
using FullStackShop.Domain.Models;
using FullStackShop.Domain.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FullStackShop.EF.Repositories;

public class ProductRepository : IProductRepository
{
    public IUnitOfWork UnitOfWork => _context;
    
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public Product Add(Product product)
    {
        return _context.Products.Add(product).Entity;
    }

    public async Task<Product?> GetAsync(int productId)
    {
        var product = await _context.Products.FindAsync(productId);

        if (product == null) return product;

        // Load navigation props
        await _context.Entry(product)
            .Reference(p => p.Category)
            .LoadAsync();
        
        return product;
    }

    public async Task<IReadOnlyCollection<Product>> GetAllAsync()
    {
        var products =  await _context.Products.ToArrayAsync();

        return products.ToImmutableArray();
    }


    // Mark entity as modified so changes are persisted
    public void Update(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
    }
}
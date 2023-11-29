using FullStackShop.Domain.Interfaces;

namespace FullStackShop.Domain.Models.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Product Add(Product product);
    Task<Product?> GetAsync(int productId);
    Task<IReadOnlyCollection<Product>> GetAllAsync();
    void Update(Product product);
}
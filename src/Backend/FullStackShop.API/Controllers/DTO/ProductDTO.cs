namespace FullStackShop.API.Controllers.DTO;

public record ProductDTO
{
    public int id { get; init; }
    public string name { get; init; }
    public string? description { get; init; }
    public decimal? price { get; init; }
    public int categoryId { get; init; }
}
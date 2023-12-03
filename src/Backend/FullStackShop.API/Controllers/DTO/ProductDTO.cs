﻿namespace FullStackShop.API.Controllers.DTO;

public record ProductDTO(
    int? id,
    string name,
    string? description,
    decimal? price,
    int categoryId
    )
{
}
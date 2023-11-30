using FullStackShop.Domain.Models;
using FullStackShop.Domain.Models.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FullStackShop.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private ILogger<ProductsController> _logger;

    public ProductsController(IProductRepository productRepository, ILogger<ProductsController> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    [HttpGet]
    [Route("/{id:int}")]
    public async Task<Results<Ok<Product>, NotFound<string>>> GetById(int id)
    {
        var product = await _productRepository.GetAsync(id);

        if (product == null) return TypedResults.NotFound($"Couldn't find product with Id: {id}");

        return TypedResults.Ok(product);
    }

    [HttpPost]
    [Route("/add")]
    public Results<Ok<Product>, BadRequest<string>, ProblemHttpResult> Add(Product product)
    {
        try
        {
            var addProduct = _productRepository.Add(product);
            
            return TypedResults.Ok(addProduct);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to add product: {@Product}", product);
            return TypedResults.Problem("Something went wrong trying to add the product!");
        }
    }
}
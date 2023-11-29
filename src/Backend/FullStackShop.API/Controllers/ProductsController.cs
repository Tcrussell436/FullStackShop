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

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
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
    public Results<Created<Product>, BadRequest<string>> Add(Product product)
    {
        try
        {

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        var addProduct = _productRepository.Add(product);
        
    }
}
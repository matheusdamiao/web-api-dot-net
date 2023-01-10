using Buber.Application.Services.Persistence;
using Buber.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Cors;

namespace BuberDinner.Api.Controllers;

[Route("product")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [EnableCors("FreePolicy")]
    [HttpGet("all")]
    public IEnumerable<Product> GetAllProducts()
    {
        return _productRepository.GetAll();

    }

    [HttpGet("{id:int}")]
    public Product GetProduct(int id)
    {
        Product item = _productRepository.Get(id);
        if (item == null)
        {
            throw new Exception("NotFound");
        }
        return item;
    }
    [HttpGet("{category}")]
    public IEnumerable<Product> GetProductByCategory(string category)
    {
        return _productRepository.GetAll().Where(
        p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
    }


    [HttpPost("{product}")]
    public HttpResponseMessage PostProduct(Product product)
    {
        var item = _productRepository.Add(product);
        var response = new HttpResponseMessage(HttpStatusCode.Created); ;
        // var uri = Url.Link("DefaultApi", new { id = item.Id });
        // response.Headers.Location = new Uri(uri);
        return response;
    }

    [HttpPut("{id}/{product}")]
    public void PutProduct(int id, Product product)
    {
        product.Id = id;
        if (!_productRepository.Update(product))
        {
            throw new Exception("NotFound");
        }

    }


    [HttpDelete("{id:int}")]
    public void DeleteProduct(int id)
    {
        Product item = _productRepository.Get(id);
        if (item == null)
        {
            throw new Exception("NotFound");
        }
        _productRepository.Remove(id);

    }
}
using Buber.Domain.Entities;
using Buber.Application.Services.Persistence;

namespace Buber.Infrastructure.Persistence;

public class ProductRepository : IProductRepository
{

    private static List<Product> _products = new();
    public int _nextId = 1;

    public ProductRepository()
    {
        // Example product Object
        // Add(new Product { Name = "Soccer Ball", Category = "Sports", Manufacturer = "Nike", Stock = 10, Price = 10 });
    }


    public IEnumerable<Product> GetAll()
    {
        return _products;
    }

    public Product Get(int id)
    {
        return _products.Find(p => p.Id == id);
    }

    public Product Add(Product product)
    {
        if (product == null)
        {
            throw new Exception("This is not a valid product");
        }
        // tried to increment user's ID but didn't work out
        // product.Id = _nextId++;
        _products.Add(product);
        return product;
    }

    public void Remove(int id)
    {
        _products.RemoveAll(p => p.Id == id);
    }


    public bool Update(Product product)
    {
        if (product == null)
        {
            throw new Exception("This is not a valid product");
        }

        int index = _products.FindIndex(p => p.Id == product.Id);

        if (index == -1)
        {
            return false;
        }
        _products.RemoveAt(index);
        _products.Add(product);
        return true;
    }

}
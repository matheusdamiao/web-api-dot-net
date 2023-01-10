using Buber.Domain.Entities;

namespace Buber.Application.Services.Persistence;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product Get(int id);
    Product Add(Product product);
    void Remove(int id);
    bool Update(Product product);
}
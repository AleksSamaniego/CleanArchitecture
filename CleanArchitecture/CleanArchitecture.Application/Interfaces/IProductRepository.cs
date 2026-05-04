using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces;

public interface IProductReadRepository
{
    IEnumerable<Product> GetAll();

    Product? GetById(int id);
}

public interface IProductWriteRepository
{
    Product Create(Product product);

    Product? Update(Product product);

    bool Delete(int id);
}
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Infrastructure.Repositories;

public class InMemoryProductRepository : IProductReadRepository, IProductWriteRepository
{
    private static readonly List<Product> Products =
    [
        new() { Id = 1, Name = "Mechanical Keyboard", Price = 89.99m, Category = "Electronics" },
        new() { Id = 2, Name = "Wireless Mouse", Price = 34.50m, Category = "Electronics" },
        new() { Id = 3, Name = "Standing Desk", Price = 249.00m, Category = "Furniture" },
        new() { Id = 4, Name = "Notebook", Price = 6.75m, Category = "Office" },
        new() { Id = 5, Name = "Water Bottle", Price = 15.20m, Category = "Lifestyle" }
    ];

    public IEnumerable<Product> GetAll() => Products;

    public Product? GetById(int id) => Products.FirstOrDefault(x => x.Id == id);

    public Product Create(Product product)
    {
        var nextId = Products.Count == 0 ? 1 : Products.Max(x => x.Id) + 1;
        product.Id = nextId;
        Products.Add(product);
        return product;
    }

    public Product? Update(Product product)
    {
        var existing = Products.FirstOrDefault(x => x.Id == product.Id);
        if (existing is null)
        {
            return null;
        }

        existing.Name = product.Name;
        existing.Price = product.Price;
        existing.Category = product.Category;

        return existing;
    }

    public bool Delete(int id)
    {
        var existing = Products.FirstOrDefault(x => x.Id == id);
        if (existing is null)
        {
            return false;
        }

        Products.Remove(existing);
        return true;
    }
}
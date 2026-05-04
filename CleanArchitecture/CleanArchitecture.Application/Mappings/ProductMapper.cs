using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Mappings;

public class ProductMapper : IProductMapper
{
    public ProductDto ToDto(Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Category = product.Category
        };
    }

    public Product ToEntity(ProductDto productDto, int? id = null)
    {
        return new Product
        {
            Id = id ?? productDto.Id,
            Name = productDto.Name,
            Price = productDto.Price,
            Category = productDto.Category
        };
    }
}
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces;

public interface IProductMapper
{
    ProductDto ToDto(Product product);

    Product ToEntity(ProductDto productDto, int? id = null);
}
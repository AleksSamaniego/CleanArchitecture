using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.Services;

public class ProductQueryService(IProductReadRepository productReadRepository, IProductMapper productMapper) : IProductQueryService
{
    public IEnumerable<ProductDto> GetAll()
    {
        return productReadRepository
            .GetAll()
            .Select(productMapper.ToDto);
    }

    public ProductDto? GetById(int id)
    {
        var product = productReadRepository.GetById(id);
        return product is null ? null : productMapper.ToDto(product);
    }
}
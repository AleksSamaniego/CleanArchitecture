using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.Services;

public class ProductCommandService(
    IProductWriteRepository productWriteRepository,
    IProductMapper productMapper,
    IProductValidator productValidator) : IProductCommandService
{
    public ProductDto Create(ProductDto productDto)
    {
        Validate(productDto);

        var product = productMapper.ToEntity(productDto);
        var created = productWriteRepository.Create(product);

        return productMapper.ToDto(created);
    }

    public ProductDto? Update(int id, ProductDto productDto)
    {
        Validate(productDto);

        var product = productMapper.ToEntity(productDto, id);
        var updated = productWriteRepository.Update(product);

        return updated is null ? null : productMapper.ToDto(updated);
    }

    public bool Delete(int id)
    {
        return productWriteRepository.Delete(id);
    }

    private void Validate(ProductDto productDto)
    {
        var errors = productValidator.Validate(productDto);

        if (errors.Count > 0)
        {
            throw new ArgumentException(string.Join(" | ", errors));
        }
    }
}
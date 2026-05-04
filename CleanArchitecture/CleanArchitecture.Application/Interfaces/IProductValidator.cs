using CleanArchitecture.Application.DTOs;

namespace CleanArchitecture.Application.Interfaces;

public interface IProductValidator
{
    IReadOnlyList<string> Validate(ProductDto productDto);
}
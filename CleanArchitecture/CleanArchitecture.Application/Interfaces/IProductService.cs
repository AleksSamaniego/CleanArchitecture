using CleanArchitecture.Application.DTOs;

namespace CleanArchitecture.Application.Interfaces;

public interface IProductQueryService
{
    IEnumerable<ProductDto> GetAll();

    ProductDto? GetById(int id);
}

public interface IProductCommandService
{
    ProductDto Create(ProductDto productDto);

    ProductDto? Update(int id, ProductDto productDto);

    bool Delete(int id);
}
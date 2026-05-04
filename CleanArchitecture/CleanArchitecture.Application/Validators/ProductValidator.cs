using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.Validators;

public class ProductValidator : IProductValidator
{
    public IReadOnlyList<string> Validate(ProductDto productDto)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(productDto.Name))
        {
            errors.Add("Name is required.");
        }

        if (productDto.Price <= 0)
        {
            errors.Add("Price must be greater than zero.");
        }

        if (string.IsNullOrWhiteSpace(productDto.Category))
        {
            errors.Add("Category is required.");
        }

        return errors;
    }
}
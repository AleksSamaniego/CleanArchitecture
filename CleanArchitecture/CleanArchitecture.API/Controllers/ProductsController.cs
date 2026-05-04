using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(
    IProductQueryService productQueryService,
    IProductCommandService productCommandService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var products = productQueryService.GetAll();
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var product = productQueryService.GetById(id);

        if (product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create(ProductDto productDto)
    {
        try
        {
            var createdProduct = productCommandService.Create(productDto);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, ProductDto productDto)
    {
        try
        {
            var updatedProduct = productCommandService.Update(id, productDto);

            if (updatedProduct is null)
            {
                return NotFound();
            }

            return Ok(updatedProduct);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var deleted = productCommandService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
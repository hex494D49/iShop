using iShop.Models;
using iShop.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
    }

    [HttpGet]
    public IActionResult GetAllPrductss()
    {
        var products = _productService.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetPrductById(int id)
    {
        var product = _productService.GetProductById(id);

        if (product == null)
        {
            return NotFound(); // 404 Not Found if product not found
        }

        return Ok(product);
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] Product product)
    {
        if (product == null)
        {
            return BadRequest(); // 400 Bad Request if product data is not provided
        }

        _productService.CreateProduct(product);

        return CreatedAtAction(nameof(GetPrductById), new { id = product.Id }, product);
        // 201 Created with a link to the newly created resource (prduct)
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
    {
        if (updatedProduct == null || id != updatedProduct.Id)
        {
            return BadRequest(); // 400 Bad Request if product data is not provided or ID mismatch
        }

        var existingProduct = _productService.GetProductById(id);

        if (existingProduct == null)
        {
            return NotFound(); // 404 Not Found if product not found
        }

        _productService.UpdateProduct(updatedProduct);

        return NoContent(); // 204 No Content if the update was successful
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = _productService.GetProductById(id);

        if (product == null)
        {
            return NotFound(); // 404 Not Found if prduct not found
        }

        _productService.DeleteProduct(id);

        return NoContent(); // 204 No Content if the deletion was successful
    }

    [HttpGet("count")]
    public IActionResult GetProductCount()
    {
        var productCount = _productService.GetProductCount();
        return Ok(productCount);
    }
}
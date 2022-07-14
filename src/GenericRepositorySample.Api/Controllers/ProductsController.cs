using Microsoft.AspNetCore.Mvc;
using GenericRepositorySample.Api.DataContexts;
using GenericRepositorySample.Api.Entities;
using GenericRepositorySample.Api.Repositories;
using GenericRepositorySample.Api.Repositories.Interfaces;

namespace GenericRepositorySample.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IGenericRepository<Product> _productRepository;

    public ProductsController(DataContext dataContext)
    {
        _productRepository = new GenericRepository<Product>(dataContext);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productRepository.GetAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        return Ok(await _productRepository.GetById(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Product product)
    {
        if (ModelState.IsValid)
        {
            await _productRepository.Add(product);
        }

        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Edit([FromBody] Product product, long id)
    {
        if (id != product.Id) return BadRequest();

        await _productRepository.Edit(product);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _productRepository.Delete(id);

        return Ok();
    }
}
using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _repository = new CategoryRepository();

    [HttpGet]
    public List<Category> GetCategories() => _repository.GetCategories();

    [HttpGet("{id}")]
    public Category GetCategory(int id) => _repository.GetCategory(id);

    [HttpPost]
    public Category PostCategory([FromBody] CategoryDTO model) => _repository.PostCategory(model);

    [HttpPut("{id}")]
    public Category PutCategory(int id, [FromBody] CategoryDTO model) => _repository.PutCategory(id, model);

    [HttpDelete("{id}")]
    public Category DeleteCategory(int id) => _repository.DeleteCategory(id);
}
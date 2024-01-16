using BusinessObject.DTO;
using BusinessObject.Models;

namespace DataAccess.Repositories;

public interface ICategoryRepository
{
    List<Category> GetCategories();
    Category GetCategory(int id);
    Category PostCategory(CategoryDTO model);
    Category PutCategory(int id, CategoryDTO model);
    Category DeleteCategory(int id);
}
using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess.DAO;

namespace DataAccess.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public List<Category> GetCategories() => CategoryDAO.GetCategories();

    public Category GetCategory(int id) => CategoryDAO.GetCategory(id);
    public Category PostCategory(CategoryDTO model) => CategoryDAO.PostCategory(model);
    public Category PutCategory(int id, CategoryDTO model) => CategoryDAO.PutCategory(id, model);
    public Category DeleteCategory(int id) => CategoryDAO.DeleteCategory(id);
}
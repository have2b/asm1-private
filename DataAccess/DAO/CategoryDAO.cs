using BusinessObject;
using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO;

public class CategoryDAO
{
    public static List<Category> GetCategories()
    {
        List<Category> categories;
        try
        {
            using var context = new AppDbContext();
            categories = context.Categories.ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in GetCategories: {e.Message}");
            throw;
        }

        return categories;
    }

    public static Category GetCategory(int id)
    {
        var category = new Category();
        try
        {
            using var context = new AppDbContext();
            category = context.Categories.SingleOrDefault(c => c.Id == id);
            if (category != null)
            {
                return category;
            }
            else
            {
                Console.WriteLine($"Category with Id {id} not found.");
                return null!;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in GetCategory: {e.Message}");
            throw;
        }
    }

    public static Category PostCategory(CategoryDTO model)
    {
        var mapper = MapperConfig.InitAutoMapper();
        var category = mapper.Map<Category>(model);
        try
        {
            using var context = new AppDbContext();
            context.Categories.Add(category);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in PostCategory: {e.Message}");
            throw;
        }

        return category;
    }


    public static Category PutCategory(int id, CategoryDTO model)
    {
        try
        {
            using var context = new AppDbContext();
            var category = context.Categories.SingleOrDefault(c => c.Id == id);

            if (category != null)
            {
                category.Name = model.Name;
                context.Categories.Update(category);
                context.SaveChanges();
                return category;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in PostCategory: {e.Message}");
            throw;
        }

        return null!;
    }

    public static Category DeleteCategory(int id)
    {
        try
        {
            using var context = new AppDbContext();
            var category = context.Categories.SingleOrDefault(c => c.Id == id);

            if (category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
                return category;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in PostCategory: {e.Message}");
            throw;
        }

        return null!;
    }
}
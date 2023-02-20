using dotnet_web_api.Models;

namespace dotnet_web_api.Services;
public class CategoryService : ICategoryService
{
    TasksContext context;
    public CategoryService(TasksContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Category> Get()
    {
        return context.Categories;
    }
    public async System.Threading.Tasks.Task Save(Category category)
    {
        context.Add(category);
        await context.SaveChangesAsync();
    }
    public async System.Threading.Tasks.Task Update(Guid id, Category category)
    {
        var currentCategory = context.Categories.Find(id);
        if(currentCategory != null)
        {
            currentCategory.Name = category.Name;
            currentCategory.Description = category.Description;
            currentCategory.Weight = category.Weight;
            await context.SaveChangesAsync();
        }
    }
    public async System.Threading.Tasks.Task Delete(Guid id)
    {
        var currentCategory = context.Categories.Find(id);
        if(currentCategory != null)
        {
            context.Remove(currentCategory);
            await context.SaveChangesAsync();
        }
    }
}
public interface ICategoryService
{
    IEnumerable<Category> Get();
    System.Threading.Tasks.Task Save(Category category);
    System.Threading.Tasks.Task Update(Guid id, Category category);
    System.Threading.Tasks.Task Delete(Guid id);
}
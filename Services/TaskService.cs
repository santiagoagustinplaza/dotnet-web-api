using dotnet_web_api.Models;

namespace dotnet_web_api.Services;
public class TaskService : ITaskService
{
    TasksContext context;
    public TaskService(TasksContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Models.Task> Get()
    {
        return (IEnumerable<Models.Task>)context.Tasks;
    }
    public async System.Threading.Tasks.Task Save(Models.Task task)
    {
        context.Add(task);
        await context.SaveChangesAsync();
    }
    public async System.Threading.Tasks.Task Update(Guid id, Models.Task task)
    {
        var currentTask = context.Tasks.Find(id);
        if(currentTask != null)
        {
            currentTask.CategoryId = task.CategoryId;
            currentTask.Title = task.Title;
            currentTask.Description = task.Description;
            currentTask.TaskPriority = task.TaskPriority;
            currentTask.CreationDate = task.CreationDate;
            currentTask.Category = task.Category;
            currentTask.Summary = task.Summary;
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
public interface ITaskService
{
    IEnumerable<Models.Task> Get();
    System.Threading.Tasks.Task Save(Models.Task task);
    System.Threading.Tasks.Task Update(Guid id, Models.Task task);
    System.Threading.Tasks.Task Delete(Guid id);
}
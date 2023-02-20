using dotnet_web_api.Models;
using Microsoft.EntityFrameworkCore;
namespace dotnet_web_api;
public class TasksContext : DbContext
{
    public DbSet<Models.Category> Categories { get; set; }
    public DbSet<Models.Task> Tasks { get; set; }
    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Models.Category> categoryInit = new List<Models.Category>();
        categoryInit.Add(new Models.Category() { CategoryId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c657"), Name = "Pending activities", Weight = 20});
        categoryInit.Add(new Models.Category() { CategoryId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c602"), Name = "Personal activities", Weight = 50});

        List<Models.Task> taskInit = new List<Models.Task>();
        taskInit.Add(new Models.Task() {TaskId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c100"), 
                                        CategoryId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c657"),
                                        TaskPriority = Priority.Medium,
                                        Title = "Payment of public services",
                                        CreationDate = DateTime.Now});
        taskInit.Add(new Models.Task() {TaskId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c101"), 
                                        CategoryId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c602"),
                                        TaskPriority = Priority.Low,
                                        Title = "Finish watching movie",
                                        CreationDate = DateTime.Now});  

        modelBuilder.Entity<Models.Category>(category=>
        {
            category.ToTable("Category");
            category.HasKey(p=>p.CategoryId);
            category.Property(p=>p.Name).IsRequired().HasMaxLength(150);
            category.Property(p=>p.Description).IsRequired(false);
            category.Property(p=>p.Weight);
            category.HasData(categoryInit);
        });
        modelBuilder.Entity<Models.Task>(task=>
        {
            task.ToTable("Task");
            task.HasOne(p=>p.Category).WithMany(p=>p.Tasks).HasForeignKey(p=>p.CategoryId);
            task.Property(p=>p.Title).IsRequired().HasMaxLength(200);
            task.Property(p=>p.Description).IsRequired(false);
            task.Property(p=>p.TaskPriority);
            task.Property(p=>p.CreationDate).HasDefaultValue(DateTime.UtcNow);
            task.Ignore(p=>p.Summary);
            task.HasData(taskInit);
        });
    }
}
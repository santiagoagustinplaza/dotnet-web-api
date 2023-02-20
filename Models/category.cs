using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace dotnet_web_api.Models;
public class Category
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Weight { get; set; }
    [JsonIgnore]
    public virtual ICollection<Task> Tasks{ get; set; }
}
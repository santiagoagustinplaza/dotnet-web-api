using Microsoft.AspNetCore.Mvc;
using dotnet_web_api.Models;
using dotnet_web_api.Services;

namespace dotnet_web_api.Controllers;

[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    ITaskService taskService;

    public TaskController(ITaskService service)
    {
        taskService = service;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(taskService.Get());
    }
    [HttpPost]
    public IActionResult Post([FromBody] Models.Task task) {
        taskService.Save(task);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Models.Task task) {
        taskService.Update(id, task);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id) {
        taskService.Delete(id);
        return Ok();
    }
}
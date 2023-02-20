using Microsoft.AspNetCore.Mvc;

namespace dotnet_web_api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;

    TasksContext dbcontext;

    public HelloWorldController(IHelloWorldService helloWorld, TasksContext db)
    {
        helloWorldService = helloWorld;
        dbcontext = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();

        return Ok();
    }
}
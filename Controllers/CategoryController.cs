using Microsoft.AspNetCore.Mvc;
using dotnet_web_api.Models;
using dotnet_web_api.Services;

namespace dotnet_web_api.Controllers;

[Route("api/[controller]")]
public class CategoryController: ControllerBase
{
    ICategoryService categoryService;

    public CategoryController(ICategoryService service)
    {
        categoryService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(categoryService.Get());
    }


    [HttpPost]
    public IActionResult Post([FromBody] Category category)
    {
        categoryService.Save(category);
        return Ok();
    }


    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Category category)
    {
        categoryService.Update(id, category);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        categoryService.Delete(id);
        return Ok();
    }    

}

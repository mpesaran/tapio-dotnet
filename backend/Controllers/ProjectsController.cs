using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Services.Interfaces;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    [HttpGet("user-projects")]
    public async Task<ActionResult<List<Project>>> GetProjectsByUser()
    {
        var userId = "687e1bc4b8e088de379ab0da";
        var projects = await projectService.GetByUserIdAsync(userId);
        Console.WriteLine("Hit the GetProjectsByUser route");
        return Ok(projects);
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        Console.WriteLine("Test route hit");
        return Ok("It's alive!");
    }
}

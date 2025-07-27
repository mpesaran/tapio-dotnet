using System.Net;
using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailsController(IEmailService emailService) : ControllerBase
{
    [HttpGet("{projectId}")]
    public async Task<ActionResult<List<Email>>> GetEmailsByProject(string projectId)
    {
        var emails = await emailService.GetByProjectIdAsync(projectId);
        return Ok(emails);
    }

    [HttpGet("test")]
    public IActionResult Test() => Ok("Emails controller is alive");

}
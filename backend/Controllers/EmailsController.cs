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
        projectId = "68859bbf55d1d55706a8bd02";
        var emails = await emailService.GetByProjectIdAsync(projectId);
        return Ok(emails);
    }

    [HttpGet("test")]
    public IActionResult Test() => Ok("Emails controller is alive");

    [HttpPut("{emailId}")]
    public async Task<ActionResult<List<Email>>> UpdateEmail(string emailId, [FromBody] UpdateEmailDto updateDto)
    {
        var updated = await emailService.UpdateEmailAsync(emailId, updateDto);
        if (!updated)
            return NotFound("Email not found or no valid fields provided.");

        return NoContent();
    }

}
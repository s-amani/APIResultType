using Microsoft.AspNetCore.Mvc;
using SaberDev.WebAPI.ResultType.Model;
using SaberDev.WebAPI.ResultType.Services;

namespace SaberDev.WebAPI.ResultType.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Employee model)
    {
        var result = await _service.Add(model);

        return result.Match<IActionResult>(
            success => CreatedAtAction(nameof(Post), new { id = success.Id }),
            failed => BadRequest(failed)
        );
    }
}

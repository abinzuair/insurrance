using CHI.Application;
using Microsoft.AspNetCore.Mvc;

namespace CHI.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Insurance : ControllerBase
{
    private readonly InsuranceService _service;
    public Insurance(InsuranceService service)
    {
        _service = service;
    }

    [HttpGet("agency-x-policies")]
    public async Task<IActionResult> AgencyX()
    {
        var result = await _service.GetPolicy(new AgencyXPolicyListResult());
        return Ok(result);
    }
    [HttpGet("agency-y-policies")]
    public async Task<IActionResult> AgencyY()
    {
        var result = await _service.GetPolicy(new AgencyYPolicyListResult());
        return Ok(result);
    }
}
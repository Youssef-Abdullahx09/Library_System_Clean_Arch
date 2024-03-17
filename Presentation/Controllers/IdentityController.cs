using Application.DTOs;
using Application.Features.Identities.Command;
using Domain.Enums;
using Infrastructure.Authorizations;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
public class IdentityController : ApiController
{
    [HttpGet]
    [HasPermission(FeatureOptions.Books, PermissionOptions.List)]
    public async Task<IActionResult> GetById()
    {
        throw new Exception("this exception is for exception handler middleware trial");
        return Ok();
    }

    [HttpPost]
    [Route(nameof(Login))]
    public async Task<IActionResult> Login(LoginRequestDTO request, CancellationToken token)
    {
        var command = new LoginCommand
        {
            Email = request.Email,
            Password = request.Password
        };

        var result = await Sender.Send(command, token);

        return Ok(result.Value);
    }
}

using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using MovieTheaterProject.API.Contracts.Responses;

namespace MovieTheaterProject.API.Endpoints;

[AllowAnonymous]
[HttpGet("api/ping")]
public class PingEndpoint : EndpointWithoutRequest<PingResponse>
{
    public override Task HandleAsync(CancellationToken ct)
    {
        var result = new PingResponse();
        return SendOkAsync(result);
    }
}

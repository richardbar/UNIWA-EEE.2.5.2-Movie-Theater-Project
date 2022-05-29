﻿using Microsoft.AspNetCore.Authorization;
using FastEndpoints;

using MovieTheaterProject.Contracts.Requests;
using MovieTheaterProject.Contracts.Responses;
using MovieTheaterProject.Services;
using MovieTheaterProject.Mapping;

namespace MovieTheaterProject.Endpoints;

[HttpDelete("api/movies/{id:guid}"), AllowAnonymous]
public sealed class DeleteMovieEndpoint : Endpoint<DeleteMovieRequest>
{
    private readonly IMovieService _movieService;

    public DeleteMovieEndpoint(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public override async Task HandleAsync(DeleteMovieRequest req, CancellationToken ct)
    {
        var deleted = await _movieService.DeleteAsync(req.Id);

        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}

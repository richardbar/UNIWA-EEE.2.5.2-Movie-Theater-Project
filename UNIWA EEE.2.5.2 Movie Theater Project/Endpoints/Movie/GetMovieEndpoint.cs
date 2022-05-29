﻿using Microsoft.AspNetCore.Authorization;
using FastEndpoints;
using MovieTheaterProject.Mapping;
using MovieTheaterProject.Contracts.Requests.Movie;
using MovieTheaterProject.Contracts.Responses.Movie;
using MovieTheaterProject.Services.Movie;

namespace MovieTheaterProject.Endpoints.Movie;

[HttpGet("/api/movies/{id:guid}"), AllowAnonymous]
public sealed class GetMovieEndpoint : Endpoint<GetMovieRequest, MovieResponse>
{
    private readonly IMovieService _movieService;

    public GetMovieEndpoint(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public override async Task HandleAsync(GetMovieRequest req, CancellationToken ct)
    {
        var movie = await _movieService.GetAsync(req.Id);

        if (movie is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var movieResponse = movie.ToMovieResponse();
        await SendOkAsync(movieResponse, ct);
    }
}
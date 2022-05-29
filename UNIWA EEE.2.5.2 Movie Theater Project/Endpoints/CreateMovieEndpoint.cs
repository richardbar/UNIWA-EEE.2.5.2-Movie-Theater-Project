﻿using Microsoft.AspNetCore.Authorization;
using FastEndpoints;

using MovieTheaterProject.Contracts.Requests;
using MovieTheaterProject.Contracts.Responses;
using MovieTheaterProject.Mapping;
using MovieTheaterProject.Services;

namespace MovieTheaterProject.Endpoints;

[HttpPost("/api/movies"), AllowAnonymous]
public sealed class CreateMovieEndpoint : Endpoint<CreateMovieRequest, MovieResponse>
{
    private readonly IMovieService _movieService;

    public CreateMovieEndpoint(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public override async Task HandleAsync(CreateMovieRequest req, CancellationToken ct)
    {
        var movie = req.ToMovie();

        await _movieService.CreateAsync(movie);

        var movieResponse = movie.ToMovieResponse();
        await SendCreatedAtAsync<GetMovieEndpoint>(
            new { Id = movie.Id.Value }, movieResponse, generateAbsoluteUrl: true, cancellation: ct);
    }
}

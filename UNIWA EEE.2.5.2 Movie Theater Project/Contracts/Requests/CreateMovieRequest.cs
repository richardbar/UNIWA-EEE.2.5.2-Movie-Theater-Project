﻿namespace MovieTheaterProject.Contracts.Requests;

public class CreateMovieRequest
{
    public string Name { get; init; } = default!;

    public float Price { get; init; } = .0f;

    public string Duration { get; init; } = default!;
}
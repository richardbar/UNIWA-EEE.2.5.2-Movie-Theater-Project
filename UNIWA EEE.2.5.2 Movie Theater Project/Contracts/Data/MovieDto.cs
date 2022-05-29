﻿namespace MovieTheaterProject.Contracts.Data;

public class MovieDto
{
    public string Id { get; init; } = default!;

    public string Name { get; init; } = default!;

    public float Price { get; init; } = .0f;

    public string Duration { get; init; } = default!;
}
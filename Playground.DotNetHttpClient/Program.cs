using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Playground.DotNetHttpClient;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddHttpClient<DeezerHttpClient>(x =>
    {
        x.BaseAddress = new("https://api.deezer.com/");
        x.DefaultRequestHeaders.Accept.Add(new(MediaTypeNames.Application.Json));
    });

var app = builder.Build();

app.MapGet("/tracks", async ([FromQuery(Name = "artist")] string artistName, DeezerHttpClient client) =>
{
    var artists = await client.GetArtist(artistName);

    var artist = artists?.Data.First();

    if (artist is null)
    {
        return Results.BadRequest(new {message = $"Artist {artistName} not found"});
    }

    var preflight = await client.GetArtistTracks(artist.Id);

    var tracks = await client.GetArtistTracks(artist.Id, preflight!.Total);

    return Results.Ok(new
    {
        Count = tracks!.Total,
        Tracks = tracks!.Data
            .Select(x => new
            {
                x.Id, 
                x.Rank,
                x.Title,
                Album = x.Album.Title,
                Duration = TimeSpan.FromSeconds(x.Duration),
            })
            .OrderByDescending(x => x.Rank)
    });
});

app.Run();





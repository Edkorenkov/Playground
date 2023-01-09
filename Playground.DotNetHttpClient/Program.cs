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

app.MapGet("/artists", async ([FromQuery] string name, DeezerHttpClient client) =>
{
    var response = await client.GetArtist(name);

    return response switch
    {
        {Data.Count: > 0} => Results.Ok(response.Data.First()),
        _ => Results.BadRequest(new {message = $"Artist {name} not found"})
    };
});

app.Run();





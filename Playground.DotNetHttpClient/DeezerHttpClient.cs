namespace Playground.DotNetHttpClient;

public sealed class DeezerHttpClient
{
    private readonly HttpClient _httpClient;

    public DeezerHttpClient(HttpClient httpClient) => _httpClient = httpClient;

    public Task<ArtistResponse?> GetArtist(string artistName)
        => _httpClient.GetFromJsonAsync<ArtistResponse>($"search/artist?q={artistName}&limit=1");
}

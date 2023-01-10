namespace Playground.DotNetHttpClient;

public sealed class DeezerHttpClient
{
    private readonly HttpClient _httpClient;

    public DeezerHttpClient(HttpClient httpClient) => _httpClient = httpClient;

    public Task<DeezerHttpResponse<ArtistModel>?> GetArtist(string artistName)
        => _httpClient.GetFromJsonAsync<DeezerHttpResponse<ArtistModel>>(
            $"search/artist?q={artistName}&limit=1");
    
    public Task<DeezerHttpResponse<TrackModel>?> GetArtistTopTracks(int artistId)
        => _httpClient.GetFromJsonAsync<DeezerHttpResponse<TrackModel>>(
            $"artist/{artistId}/top?limit=100");
}

namespace Playground.DotNetHttpClient;

public class ArtistResponse
{
    public int Total { get; set; }
    public IReadOnlyCollection<Artist> Data { get; set; } = Array.Empty<Artist>();
}

public class Artist
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Link { get; set; } = "";
    public string Tracklist { get; set; } = "";
}
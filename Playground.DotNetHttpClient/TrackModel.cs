namespace Playground.DotNetHttpClient;

public class TrackModel
{
    public int Id { get; init; }
    public int Rank { get; init; }
    public int Duration { get; set; }
    public string Title { get; init; } = "";
    public AlbumModel Album { get; init; } = null!;
}
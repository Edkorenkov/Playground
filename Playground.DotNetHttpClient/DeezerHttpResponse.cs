namespace Playground.DotNetHttpClient;

public class DeezerHttpResponse<TModel> where TModel : class
{
    public int Total { get; init; }
    public IReadOnlyCollection<TModel> Data { get; init; } = Array.Empty<TModel>();
}
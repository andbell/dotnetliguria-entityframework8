namespace DotNetLiguria.EF8.WebApi.RequestModels
{
    public class MovieRequest
    {
        public required string Title { get; set; }
        public required List<string> Genres { get; set; } = new ();
    }
}

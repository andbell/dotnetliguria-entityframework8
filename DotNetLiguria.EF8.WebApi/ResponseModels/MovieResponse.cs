namespace DotNetLiguria.EF8.WebApi.ResponseModels
{
    public class MovieResponse
    {
        public int MovieId { get; set; }
        public required string Title { get; set; }
        public required string FirstGenre { get; set; }
    }
}

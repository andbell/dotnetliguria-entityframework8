namespace DotNetLiguria.EF8.Models;

public class Movie
{
    public Movie(string title, string[] genres)
    {
        Title = title;
        Genres = genres;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string[] Genres { get; set; }
}

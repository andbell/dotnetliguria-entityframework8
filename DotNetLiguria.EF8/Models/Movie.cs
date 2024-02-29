namespace DotNetLiguria.EF8.Models;

public class Movie(string title, string[] genres)
{
    public int Id { get; set; }
    public string Title { get; set; } = title;
    public string[] Genres { get; set; } = genres;
}

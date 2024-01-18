namespace DotNetLiguria.EF8.Models;

public class CinemaRoom
{
    public CinemaRoom(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public ScreenType ScreenType { get; set; }

    public List<DateOnly> OpenDates { get; private set; } = new();

    public Movie ActualMovie { get; set; }
}

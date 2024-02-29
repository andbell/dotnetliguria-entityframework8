namespace DotNetLiguria.EF8.Models;

public class CinemaRoom(string name)
{
    public int Id { get; set; }
    public string Name { get; set; } = name;

    public ScreenType ScreenType { get; set; }

    public List<DateOnly> OpenDates { get; private set; } = [];

    public Movie? ActualMovie { get; set; }
}

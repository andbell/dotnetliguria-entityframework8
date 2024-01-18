using Microsoft.EntityFrameworkCore;

namespace DotNetLiguria.EF8.Models;

public class Person
{
    public Person(HierarchyId path, string name)
    {
        Path = path;
        Name = name;
    }

    public int Id { get; set; }
    public HierarchyId Path { get; set; }
    public string Name { get; set; }
}

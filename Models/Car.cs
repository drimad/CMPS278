namespace Cars.Models;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; } = null!;
    public string Color { get; set; } = null!;
    public int Year { get; set; }
    public int NumberOfDoors { get; set; }
}


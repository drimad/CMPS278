namespace Cars.Models;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; } = null!;
    public string Color { get; set; } = default!;
    public int Year { get; set; }
}


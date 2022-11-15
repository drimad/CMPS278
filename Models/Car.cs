using System.ComponentModel.DataAnnotations;

namespace Cars.Models;

public class Car
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Brand { get; set; } = null!;

    [Required]
    public string Color { get; set; } = null!;

    [Required]
    [Range(1980, 2022)]
    public int Year { get; set; }

    public int NumberOfDoors { get; set; }
}


#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
// Add this using statement to access NotMapped
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefNDishes.Models;

public class Dish
{
    [Key]
    public int DishId {get; set;}
    [Required]
    public string Name {get;set;}
    [Required]
    public int Calories {get;set;}
    [Required]
    public int Tastiness {get;set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [Required]
    public int ChefId {get;set;}

    public Chef? Creator {get; set;}
}
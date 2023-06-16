#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
// Add this using statement to access NotMapped
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefNDishes.Models;

public class Chef
{
    [Key]
    public int ChefId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [OldEnough]
    public DateTime DBO { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Dish> AllDishes { get; set; } = new List<Dish>();
}

public class OldEnoughAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        // Though we have Required as a validation, sometimes we make it here anyways
        // In which case we must first verify the value is not null before we proceed
        if (value == null)
        {
            // If it was, return the required error
            return new ValidationResult("Please enter a Birth date!");
        }
        // This will connect us to our database since we are not in our Controller
        // Check to see if there are any records of this email in our database
        DateTime BOD = (DateTime)value;
        int age = DateTime.Now.Year - BOD.Year;
        if (age < 18)
        {
            // If yes, throw an error
            return new ValidationResult("Chef must be at least 18 years old!");
        }
        else
        {
            //     // If no, proceed
            return ValidationResult.Success;
        }
    }
}
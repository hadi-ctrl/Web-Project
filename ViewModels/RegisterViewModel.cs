using System.ComponentModel.DataAnnotations;

namespace Project.ViewModels;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    
    [Required]
    public string? FirstName { get; set; }
    
    [Required]
    public string? LastName { get; set; }
    [Required]
    public string? Gender { get; set; }
    [Required]
    public string? Major { get; set; }
    
}
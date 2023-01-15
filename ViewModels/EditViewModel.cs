using System.ComponentModel.DataAnnotations;

namespace Project.ViewModels;

public class EditViewModel
{
    [EmailAddress]
    public string? Email { get; set; }
    
    [DataType(DataType.Password)]
    public string? OldPassword { get; set; }
    
    [DataType(DataType.Password)]
    public string? NewPassword { get; set; }
}
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Project.Models;

public class ApplicationUser : IdentityUser
{
    public ApplicationUser(){}
    public string? FirstName { get; set; }

    public string? LastName { get; set; }
    public override string? PhoneNumber { get; set; }

    public string? Gender { get; set; }
    public string? Major { get; set; }

    public string? About { get; set; }

    public string? Rate { get; set; }

    public string? ImageURL { get; set; }

    public string UserType { get; set; }

    public DateTime DateCreated { get; set; }
}
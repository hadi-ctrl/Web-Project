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

    public string? ImageURL { get; set; } = "https://imgs.search.brave.com/EAgA3GVRAsj90q4zZtH_Q5Utv3ccTIEx8Q7UWJRq1eE/rs:fit:240:225:1/g:ce/aHR0cHM6Ly90c2Ux/Lm1tLmJpbmcubmV0/L3RoP2lkPU9JUC5t/cm53Z1VKTFpFbFRC/S05mejg5YlpRQUFB/QSZwaWQ9QXBp";

    public string UserType { get; set; }

    public DateTime DateCreated { get; set; }
}
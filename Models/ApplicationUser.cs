using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Hugolf.Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string BirthDate { get; set; }

    public string? StreetAddress { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string MembershipType { get; set; } = "Casual";
}

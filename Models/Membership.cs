using System;
using System.ComponentModel.DataAnnotations;

namespace Hugolf.Models;

public class Membership
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    [Display(Name = "Membership Type")]
    public string MembershipType { get; set; }

    public string? Description { get; set; }

    [Required]
    [Display(Name = "Membership Price")]
    [Range(1, 5000)]
    public double MembershipPrice { get; set; }

    [Display(Name = "Joining Fee")]
    [Range(0, 500)]
    public double? JoiningFee { get; set; }

    public string? Condition { get; set; }
}

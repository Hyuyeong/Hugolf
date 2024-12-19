using System;
using System.ComponentModel.DataAnnotations;

namespace Hugolf.Models;

public class CourseStatus
{
    [Key]
    public int Id { get; set; }

    [Required]
    public bool Cart { get; set; } // Indicates whether carts are available (true for Yes, false for No)

    [Required]
    public bool Bag { get; set; } // Indicates whether bags are allowed (true for Yes, false for No)

    [Required]
    public bool Trundler { get; set; } // Indicates whether trundlers are available (true for Yes, false for No)

    [Required]
    public bool IsCourseOpen { get; set; } // true for Open, false for Closed

    [MaxLength(500)]
    public string? Notes { get; set; } // Optional notes about the course status
}

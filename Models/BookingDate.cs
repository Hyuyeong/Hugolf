using System;
using System.ComponentModel.DataAnnotations;

namespace Hugolf.Models;

public class BookingDate
{
    [Key]
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public bool IsAvailable { get; set; }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Hugolf.Models;

public class BookingTime
{
    public int Id { get; set; }
    public int BookingDateId { get; set; }

    [ForeignKey("BookingDateId")]
    [ValidateNever]
    public BookingDate BookingDate { get; set; }

    public TimeOnly Time { get; set; }

    public string? PlayerOne { get; set; }
    public string? PlayerTwo { get; set; }
    public string? PlayerThree { get; set; }
    public string? PlayerFour { get; set; }
}

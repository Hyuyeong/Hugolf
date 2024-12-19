using System;
using Hugolf.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hugolf.Data;

public class ApplictionDbContext : IdentityDbContext
{
    public ApplictionDbContext(DbContextOptions<ApplictionDbContext> options)
        : base(options) { }

    public DbSet<Membership> Memberships { get; set; }
    public DbSet<BookingDate> BookingDates { get; set; }
    public DbSet<BookingTime> BookingTimes { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<CourseStatus> CourseStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<Membership>()
            .HasData(
                new Membership
                {
                    Id = 1,
                    MembershipType = "Full",
                    Description = "7 days a week, unlimited play",
                    Condition = "",
                    JoiningFee = 500,
                    MembershipPrice = 1600,
                },
                new Membership
                {
                    Id = 2,
                    MembershipType = "Weekday",
                    Description = "Monday - Friday + public holidays",
                    Condition = "",
                    JoiningFee = 250,
                    MembershipPrice = 1200,
                },
                new Membership
                {
                    Id = 3,
                    MembershipType = "9Hole",
                    Description = "7 days a week",
                    Condition = "Play only available after 12pm daily",
                    JoiningFee = 0,
                    MembershipPrice = 1600,
                },
                new Membership
                {
                    Id = 4,
                    MembershipType = "Junior",
                    Description = "7 days a week, unlimited play",
                    Condition = "",
                    JoiningFee = 0,
                    MembershipPrice = 120,
                }
            );
        modelBuilder
            .Entity<CourseStatus>()
            .HasData(
                new CourseStatus
                {
                    Id = 1,
                    Cart = true,
                    Bag = true,
                    Trundler = false,
                    IsCourseOpen = true,
                    Notes = "Course is open but trundlers are unavailable due to maintenance.",
                }
            );
    }
}

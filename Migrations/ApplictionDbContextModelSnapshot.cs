﻿// <auto-generated />
using System;
using Hugolf.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hugolf.Migrations
{
    [DbContext(typeof(ApplictionDbContext))]
    partial class ApplictionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Hugolf.Models.BookingDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("BookingDates");
                });

            modelBuilder.Entity("Hugolf.Models.BookingTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookingDateId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlayerFour")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayerOne")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayerThree")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayerTwo")
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookingDateId");

                    b.ToTable("BookingTimes");
                });

            modelBuilder.Entity("Hugolf.Models.Membership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Condition")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<double?>("JoiningFee")
                        .HasColumnType("REAL");

                    b.Property<double>("MembershipPrice")
                        .HasColumnType("REAL");

                    b.Property<string>("MembershipType")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Memberships");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Condition = "",
                            Description = "7 days a week, unlimited play",
                            JoiningFee = 500.0,
                            MembershipPrice = 1600.0,
                            MembershipType = "Full"
                        },
                        new
                        {
                            Id = 2,
                            Condition = "",
                            Description = "Monday - Friday + public holidays",
                            JoiningFee = 250.0,
                            MembershipPrice = 1200.0,
                            MembershipType = "Weekday"
                        },
                        new
                        {
                            Id = 3,
                            Condition = "Play only available after 12pm daily",
                            Description = "7 days a week",
                            JoiningFee = 0.0,
                            MembershipPrice = 1600.0,
                            MembershipType = "9Hole"
                        },
                        new
                        {
                            Id = 4,
                            Condition = "",
                            Description = "7 days a week, unlimited play",
                            JoiningFee = 0.0,
                            MembershipPrice = 120.0,
                            MembershipType = "Junior"
                        });
                });

            modelBuilder.Entity("Hugolf.Models.BookingTime", b =>
                {
                    b.HasOne("Hugolf.Models.BookingDate", "BookingDate")
                        .WithMany()
                        .HasForeignKey("BookingDateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingDate");
                });
#pragma warning restore 612, 618
        }
    }
}

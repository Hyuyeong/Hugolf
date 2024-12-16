using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hugolf.Migrations
{
    /// <inheritdoc />
    public partial class BookingTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookingDateId = table.Column<int>(type: "INTEGER", nullable: false),
                    Time = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    PlayerOne = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerTwo = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerThree = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerFour = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingTimes_BookingDates_BookingDateId",
                        column: x => x.BookingDateId,
                        principalTable: "BookingDates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingTimes_BookingDateId",
                table: "BookingTimes",
                column: "BookingDateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingTimes");
        }
    }
}

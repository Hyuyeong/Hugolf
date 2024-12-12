using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hugolf.Migrations
{
    /// <inheritdoc />
    public partial class updateMembershipModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "Memberships",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Memberships",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "JoiningFee",
                table: "Memberships",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MembershipPrice",
                table: "Memberships",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Condition", "Description", "JoiningFee", "MembershipPrice" },
                values: new object[] { "", "7 days a week, unlimited play", 500.0, 1600.0 });

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Condition", "Description", "JoiningFee", "MembershipPrice" },
                values: new object[] { "", "Monday - Friday + public holidays", 250.0, 1200.0 });

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Condition", "Description", "JoiningFee", "MembershipPrice" },
                values: new object[] { "Play only available after 12pm daily", "7 days a week", 0.0, 1600.0 });

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Condition", "Description", "JoiningFee", "MembershipPrice" },
                values: new object[] { "", "7 days a week, unlimited play", 0.0, 120.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "JoiningFee",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "MembershipPrice",
                table: "Memberships");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hugolf.Migrations
{
    /// <inheritdoc />
    public partial class CourseStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cart = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    Bag = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    Trundler = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    IsCourseOpen = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStatuses", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStatuses");
        }
    }
}

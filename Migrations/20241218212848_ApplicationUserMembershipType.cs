﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hugolf.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationUserMembershipType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MembershipType",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembershipType",
                table: "AspNetUsers");
        }
    }
}

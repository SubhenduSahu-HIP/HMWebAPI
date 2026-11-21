using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HM_Admin.Migrations
{
    /// <inheritdoc />
    public partial class Addnewfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AdminUser",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AdminUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "AdminUser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "AdminUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "AdminUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserRole",
                table: "AdminUser",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AdminUser");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AdminUser");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "AdminUser");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AdminUser");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "AdminUser");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "AdminUser");
        }
    }
}

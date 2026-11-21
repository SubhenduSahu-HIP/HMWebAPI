using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HM_Admin.Migrations
{
    /// <inheritdoc />
    public partial class Modifiedthenameofcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserRole",
                table: "AdminUser",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "UserPassword",
                table: "AdminUser",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "UserMobile",
                table: "AdminUser",
                newName: "Mobile");

            migrationBuilder.RenameColumn(
                name: "UserLastName",
                table: "AdminUser",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "UserFirstName",
                table: "AdminUser",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "AdminUser",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "UserAddress",
                table: "AdminUser",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_AdminUser_UserEmail",
                table: "AdminUser",
                newName: "IX_AdminUser_Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "AdminUser",
                newName: "UserRole");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "AdminUser",
                newName: "UserPassword");

            migrationBuilder.RenameColumn(
                name: "Mobile",
                table: "AdminUser",
                newName: "UserMobile");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AdminUser",
                newName: "UserLastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AdminUser",
                newName: "UserFirstName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "AdminUser",
                newName: "UserEmail");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "AdminUser",
                newName: "UserAddress");

            migrationBuilder.RenameIndex(
                name: "IX_AdminUser_Email",
                table: "AdminUser",
                newName: "IX_AdminUser_UserEmail");
        }
    }
}

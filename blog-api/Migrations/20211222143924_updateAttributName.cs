using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog_api.Migrations
{
    public partial class updateAttributName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "registerDate",
                table: "Users",
                newName: "RegisterDate");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "admin",
                table: "Users",
                newName: "Admin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegisterDate",
                table: "Users",
                newName: "registerDate");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Admin",
                table: "Users",
                newName: "admin");
        }
    }
}

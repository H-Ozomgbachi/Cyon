using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyon.Infrastructure.Migrations
{
    public partial class Apology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "AttendanceRegisters",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Apologies",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AttendanceRegisters",
                newName: "UserEmail");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Apologies",
                newName: "UserEmail");
        }
    }
}

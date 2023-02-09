using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyon.Infrastructure.Migrations
{
    public partial class YearProgramme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "UserFinances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 30, 20, 49, 49, 10, DateTimeKind.Local).AddTicks(1080),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 28, 17, 40, 8, 775, DateTimeKind.Local).AddTicks(225));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "OrganisationFinances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 30, 19, 49, 49, 10, DateTimeKind.Utc).AddTicks(2514),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 28, 16, 40, 8, 775, DateTimeKind.Utc).AddTicks(900));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Chaplains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 30, 20, 49, 49, 9, DateTimeKind.Local).AddTicks(1074),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 28, 17, 40, 8, 774, DateTimeKind.Local).AddTicks(4778));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 30, 20, 49, 49, 9, DateTimeKind.Local).AddTicks(2599),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 28, 17, 40, 8, 774, DateTimeKind.Local).AddTicks(5929));

            migrationBuilder.CreateTable(
                name: "YearProgrammes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Scope = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearProgrammes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YearProgrammes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "UserFinances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 17, 40, 8, 775, DateTimeKind.Local).AddTicks(225),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 30, 20, 49, 49, 10, DateTimeKind.Local).AddTicks(1080));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "OrganisationFinances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 16, 40, 8, 775, DateTimeKind.Utc).AddTicks(900),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 30, 19, 49, 49, 10, DateTimeKind.Utc).AddTicks(2514));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Chaplains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 17, 40, 8, 774, DateTimeKind.Local).AddTicks(4778),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 30, 20, 49, 49, 9, DateTimeKind.Local).AddTicks(1074));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 17, 40, 8, 774, DateTimeKind.Local).AddTicks(5929),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 30, 20, 49, 49, 9, DateTimeKind.Local).AddTicks(2599));
        }
    }
}

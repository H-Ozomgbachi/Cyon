using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyon.Infrastructure.Migrations
{
    public partial class OrganisationFinanceAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "UserFinances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 4, 10, 29, 51, 680, DateTimeKind.Local).AddTicks(5390),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 2, 19, 18, 18, 257, DateTimeKind.Local).AddTicks(7414));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Chaplains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 4, 10, 29, 51, 679, DateTimeKind.Local).AddTicks(4485),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 2, 19, 18, 18, 257, DateTimeKind.Local).AddTicks(2756));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 4, 10, 29, 51, 679, DateTimeKind.Local).AddTicks(6315),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 2, 19, 18, 18, 257, DateTimeKind.Local).AddTicks(3538));

            migrationBuilder.CreateTable(
                name: "OrganisationFinances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinanceType = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 1, 4, 9, 29, 51, 680, DateTimeKind.Utc).AddTicks(6843))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationFinances", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganisationFinances");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "UserFinances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 2, 19, 18, 18, 257, DateTimeKind.Local).AddTicks(7414),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 4, 10, 29, 51, 680, DateTimeKind.Local).AddTicks(5390));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Chaplains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 2, 19, 18, 18, 257, DateTimeKind.Local).AddTicks(2756),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 4, 10, 29, 51, 679, DateTimeKind.Local).AddTicks(4485));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 2, 19, 18, 18, 257, DateTimeKind.Local).AddTicks(3538),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 4, 10, 29, 51, 679, DateTimeKind.Local).AddTicks(6315));
        }
    }
}

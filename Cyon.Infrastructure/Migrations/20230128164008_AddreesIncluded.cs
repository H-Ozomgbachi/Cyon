using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyon.Infrastructure.Migrations
{
    public partial class AddreesIncluded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "UserFinances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 17, 40, 8, 775, DateTimeKind.Local).AddTicks(225),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 4, 10, 29, 51, 680, DateTimeKind.Local).AddTicks(5390));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "OrganisationFinances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 16, 40, 8, 775, DateTimeKind.Utc).AddTicks(900),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 4, 9, 29, 51, 680, DateTimeKind.Utc).AddTicks(6843));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Chaplains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 17, 40, 8, 774, DateTimeKind.Local).AddTicks(4778),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 4, 10, 29, 51, 679, DateTimeKind.Local).AddTicks(4485));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 17, 40, 8, 774, DateTimeKind.Local).AddTicks(5929),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 4, 10, 29, 51, 679, DateTimeKind.Local).AddTicks(6315));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "UserFinances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 4, 10, 29, 51, 680, DateTimeKind.Local).AddTicks(5390),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 28, 17, 40, 8, 775, DateTimeKind.Local).AddTicks(225));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "OrganisationFinances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 4, 9, 29, 51, 680, DateTimeKind.Utc).AddTicks(6843),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 28, 16, 40, 8, 775, DateTimeKind.Utc).AddTicks(900));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Chaplains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 4, 10, 29, 51, 679, DateTimeKind.Local).AddTicks(4485),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 28, 17, 40, 8, 774, DateTimeKind.Local).AddTicks(4778));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 4, 10, 29, 51, 679, DateTimeKind.Local).AddTicks(6315),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 28, 17, 40, 8, 774, DateTimeKind.Local).AddTicks(5929));
        }
    }
}

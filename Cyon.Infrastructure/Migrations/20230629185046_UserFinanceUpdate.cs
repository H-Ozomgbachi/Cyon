using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyon.Infrastructure.Migrations
{
    public partial class UserFinanceUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "UserFinances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 19, 50, 46, 504, DateTimeKind.Local).AddTicks(964),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 29, 10, 18, 7, 694, DateTimeKind.Local).AddTicks(9792));

            migrationBuilder.AddColumn<string>(
                name: "FinanceType",
                table: "UserFinances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "OrganisationFinances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 18, 50, 46, 504, DateTimeKind.Utc).AddTicks(2066),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 29, 9, 18, 7, 695, DateTimeKind.Utc).AddTicks(1066));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Chaplains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 19, 50, 46, 503, DateTimeKind.Local).AddTicks(3459),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 29, 10, 18, 7, 694, DateTimeKind.Local).AddTicks(5894));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 19, 50, 46, 503, DateTimeKind.Local).AddTicks(4705),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 29, 10, 18, 7, 694, DateTimeKind.Local).AddTicks(6534));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinanceType",
                table: "UserFinances");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "UserFinances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 10, 18, 7, 694, DateTimeKind.Local).AddTicks(9792),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 29, 19, 50, 46, 504, DateTimeKind.Local).AddTicks(964));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "OrganisationFinances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 9, 18, 7, 695, DateTimeKind.Utc).AddTicks(1066),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 29, 18, 50, 46, 504, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Chaplains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 10, 18, 7, 694, DateTimeKind.Local).AddTicks(5894),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 29, 19, 50, 46, 503, DateTimeKind.Local).AddTicks(3459));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 10, 18, 7, 694, DateTimeKind.Local).AddTicks(6534),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 29, 19, 50, 46, 503, DateTimeKind.Local).AddTicks(4705));
        }
    }
}

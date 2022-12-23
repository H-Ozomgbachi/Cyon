using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyon.Infrastructure.Migrations
{
    public partial class Checking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f03d11b-ae41-4f11-b80c-5cbec0d31588");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "968b2e6a-b2d7-4b61-a0d0-afac012c6937");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7beddcc-43f6-447f-87b6-edffc1776291");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Chaplains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 22, 9, 50, 50, 230, DateTimeKind.Local).AddTicks(5434),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 22, 9, 45, 30, 513, DateTimeKind.Local).AddTicks(3348));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 22, 9, 50, 50, 230, DateTimeKind.Local).AddTicks(6053),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 22, 9, 45, 30, 513, DateTimeKind.Local).AddTicks(4178));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Chaplains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 22, 9, 45, 30, 513, DateTimeKind.Local).AddTicks(3348),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 22, 9, 50, 50, 230, DateTimeKind.Local).AddTicks(5434));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 22, 9, 45, 30, 513, DateTimeKind.Local).AddTicks(4178),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 22, 9, 50, 50, 230, DateTimeKind.Local).AddTicks(6053));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7f03d11b-ae41-4f11-b80c-5cbec0d31588", "e67a2b86-0802-480c-b87e-257ecb310069", "Executive", "EXECUTIVE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "968b2e6a-b2d7-4b61-a0d0-afac012c6937", "d8235dbe-225b-43e4-a43e-3b4817f65f46", "Super", "SUPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7beddcc-43f6-447f-87b6-edffc1776291", "636bc156-6f32-44bb-bd23-e8f5f9395296", "Member", "MEMBER" });
        }
    }
}

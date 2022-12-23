using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyon.Infrastructure.Migrations
{
    public partial class Check : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "245eb4ed-2417-4849-bce4-6e73477d06dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4974aa17-7b8f-4cb8-a3cb-5c60269d8f08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ff64a7c-0851-4a63-81b1-1e2e141226b0");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Chaplains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 22, 9, 45, 30, 513, DateTimeKind.Local).AddTicks(3348),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 22, 9, 35, 14, 360, DateTimeKind.Local).AddTicks(4483));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 22, 9, 45, 30, 513, DateTimeKind.Local).AddTicks(4178),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 22, 9, 35, 14, 360, DateTimeKind.Local).AddTicks(5870));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2022, 12, 22, 9, 35, 14, 360, DateTimeKind.Local).AddTicks(4483),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 22, 9, 45, 30, 513, DateTimeKind.Local).AddTicks(3348));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 22, 9, 35, 14, 360, DateTimeKind.Local).AddTicks(5870),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 22, 9, 45, 30, 513, DateTimeKind.Local).AddTicks(4178));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "245eb4ed-2417-4849-bce4-6e73477d06dc", "9bea5d09-2983-4396-add3-3318dba27cd4", "Super", "SUPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4974aa17-7b8f-4cb8-a3cb-5c60269d8f08", "3a93aba7-005d-4a39-9b33-5563aebd91e6", "Executive", "EXECUTIVE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ff64a7c-0851-4a63-81b1-1e2e141226b0", "2004f20c-d597-4988-a031-baeafb4afcef", "Member", "MEMBER" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyon.Infrastructure.Migrations
{
    public partial class AddOccupationModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Occupations_AspNetUsers_UserId1",
                table: "Occupations");

            migrationBuilder.DropIndex(
                name: "IX_Occupations_UserId1",
                table: "Occupations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bbacbf3-5397-4bab-bc0d-ed21e2249f66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4631cd7-8055-4303-892d-9dce0a217945");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7d233e0-ba5a-44c0-8180-9690ce322b1a");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Occupations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Chaplains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 22, 9, 33, 42, 188, DateTimeKind.Local).AddTicks(2376),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 22, 9, 30, 33, 175, DateTimeKind.Local).AddTicks(3953));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 22, 9, 33, 42, 188, DateTimeKind.Local).AddTicks(3468),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 22, 9, 30, 33, 175, DateTimeKind.Local).AddTicks(4997));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "33fb967c-6653-445e-8b50-646945a6f93d", "62aacd5b-de75-4e85-9d4c-eb162c94f159", "Super", "SUPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db53ae3a-4a07-44ad-b38e-14d8bf8f9043", "5f071351-5a2e-42cd-961f-7fa6abc40e52", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e2a1a57e-6212-40c1-9419-f81fbc61856f", "5983908b-18fa-4f64-a312-71f8b8c7a533", "Executive", "EXECUTIVE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33fb967c-6653-445e-8b50-646945a6f93d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db53ae3a-4a07-44ad-b38e-14d8bf8f9043");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2a1a57e-6212-40c1-9419-f81fbc61856f");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Occupations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Chaplains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 22, 9, 30, 33, 175, DateTimeKind.Local).AddTicks(3953),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 22, 9, 33, 42, 188, DateTimeKind.Local).AddTicks(2376));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 22, 9, 30, 33, 175, DateTimeKind.Local).AddTicks(4997),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 22, 9, 33, 42, 188, DateTimeKind.Local).AddTicks(3468));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8bbacbf3-5397-4bab-bc0d-ed21e2249f66", "4ddcbabe-2f6a-465f-8151-d832f5205744", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c4631cd7-8055-4303-892d-9dce0a217945", "0b019c0d-bb36-4b23-a674-b05d31e1e56b", "Super", "SUPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7d233e0-ba5a-44c0-8180-9690ce322b1a", "723af7c3-a01e-4bb2-be2b-74a270981cad", "Executive", "EXECUTIVE" });

            migrationBuilder.CreateIndex(
                name: "IX_Occupations_UserId1",
                table: "Occupations",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Occupations_AspNetUsers_UserId1",
                table: "Occupations",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyon.Infrastructure.Migrations
{
    public partial class AddOccupationModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2022, 12, 22, 9, 35, 14, 360, DateTimeKind.Local).AddTicks(4483),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 22, 9, 33, 42, 188, DateTimeKind.Local).AddTicks(2376));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 22, 9, 35, 14, 360, DateTimeKind.Local).AddTicks(5870),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 22, 9, 33, 42, 188, DateTimeKind.Local).AddTicks(3468));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "245eb4ed-2417-4849-bce4-6e73477d06dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4974aa17-7b8f-4cb8-a3cb-5c60269d8f08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ff64a7c-0851-4a63-81b1-1e2e141226b0");

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
                oldDefaultValue: new DateTime(2022, 12, 22, 9, 35, 14, 360, DateTimeKind.Local).AddTicks(4483));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 22, 9, 33, 42, 188, DateTimeKind.Local).AddTicks(3468),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 22, 9, 35, 14, 360, DateTimeKind.Local).AddTicks(5870));

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyon.Infrastructure.Migrations
{
    public partial class AddOccupation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "736aeae7-17ae-42b1-afe1-c446165c294f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8781c1d9-8a69-48c0-bf88-31ea4ae6b45b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3454d96-300e-4331-887b-c22d1508e20f");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Chaplains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 22, 9, 30, 33, 175, DateTimeKind.Local).AddTicks(3953),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 21, 11, 16, 52, 671, DateTimeKind.Local).AddTicks(6372));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 22, 9, 30, 33, 175, DateTimeKind.Local).AddTicks(4997),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 21, 11, 16, 52, 671, DateTimeKind.Local).AddTicks(7451));

            migrationBuilder.CreateTable(
                name: "Occupations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsStudent = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsUnemployed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CanDo = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: ""),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occupations_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Occupations");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Chaplains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 21, 11, 16, 52, 671, DateTimeKind.Local).AddTicks(6372),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 22, 9, 30, 33, 175, DateTimeKind.Local).AddTicks(3953));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 21, 11, 16, 52, 671, DateTimeKind.Local).AddTicks(7451),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 22, 9, 30, 33, 175, DateTimeKind.Local).AddTicks(4997));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "736aeae7-17ae-42b1-afe1-c446165c294f", "361266af-b24e-4efc-a9dc-8f84492542ac", "Executive", "EXECUTIVE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8781c1d9-8a69-48c0-bf88-31ea4ae6b45b", "c9fc9f7d-d06a-4e30-a5b3-c19470803b7c", "Super", "SUPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3454d96-300e-4331-887b-c22d1508e20f", "16bc1e21-e3a1-4f50-bfbe-d74e1f522c37", "Member", "MEMBER" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyon.Infrastructure.Migrations
{
    public partial class userfinancechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFinances_AspNetUsers_UserId",
                table: "UserFinances");

            migrationBuilder.DropIndex(
                name: "IX_UserFinances_UserId",
                table: "UserFinances");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserFinances",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "UserFinances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 9, 12, 29, 45, 409, DateTimeKind.Local).AddTicks(7267),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 30, 20, 49, 49, 10, DateTimeKind.Local).AddTicks(1080));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserFinances",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "OrganisationFinances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 9, 11, 29, 45, 409, DateTimeKind.Utc).AddTicks(7798),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 30, 19, 49, 49, 10, DateTimeKind.Utc).AddTicks(2514));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Chaplains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 9, 12, 29, 45, 409, DateTimeKind.Local).AddTicks(3559),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 30, 20, 49, 49, 9, DateTimeKind.Local).AddTicks(1074));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 9, 12, 29, 45, 409, DateTimeKind.Local).AddTicks(4176),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 30, 20, 49, 49, 9, DateTimeKind.Local).AddTicks(2599));

            migrationBuilder.CreateIndex(
                name: "IX_UserFinances_UserId1",
                table: "UserFinances",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFinances_AspNetUsers_UserId1",
                table: "UserFinances",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFinances_AspNetUsers_UserId1",
                table: "UserFinances");

            migrationBuilder.DropIndex(
                name: "IX_UserFinances_UserId1",
                table: "UserFinances");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserFinances");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserFinances",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "UserFinances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 30, 20, 49, 49, 10, DateTimeKind.Local).AddTicks(1080),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 9, 12, 29, 45, 409, DateTimeKind.Local).AddTicks(7267));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "OrganisationFinances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 30, 19, 49, 49, 10, DateTimeKind.Utc).AddTicks(2514),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 9, 11, 29, 45, 409, DateTimeKind.Utc).AddTicks(7798));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Chaplains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 30, 20, 49, 49, 9, DateTimeKind.Local).AddTicks(1074),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 9, 12, 29, 45, 409, DateTimeKind.Local).AddTicks(3559));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 30, 20, 49, 49, 9, DateTimeKind.Local).AddTicks(2599),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 9, 12, 29, 45, 409, DateTimeKind.Local).AddTicks(4176));

            migrationBuilder.CreateIndex(
                name: "IX_UserFinances_UserId",
                table: "UserFinances",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFinances_AspNetUsers_UserId",
                table: "UserFinances",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyon.Infrastructure.Migrations
{
    public partial class userfinancechange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2023, 2, 9, 12, 38, 23, 799, DateTimeKind.Local).AddTicks(9996),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 9, 12, 29, 45, 409, DateTimeKind.Local).AddTicks(7267));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "OrganisationFinances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 9, 11, 38, 23, 800, DateTimeKind.Utc).AddTicks(1026),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 9, 11, 29, 45, 409, DateTimeKind.Utc).AddTicks(7798));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Chaplains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 9, 12, 38, 23, 799, DateTimeKind.Local).AddTicks(3696),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 9, 12, 29, 45, 409, DateTimeKind.Local).AddTicks(3559));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 9, 12, 38, 23, 799, DateTimeKind.Local).AddTicks(4815),
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2023, 2, 9, 12, 38, 23, 799, DateTimeKind.Local).AddTicks(9996));

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
                oldDefaultValue: new DateTime(2023, 2, 9, 11, 38, 23, 800, DateTimeKind.Utc).AddTicks(1026));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Chaplains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 9, 12, 29, 45, 409, DateTimeKind.Local).AddTicks(3559),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 9, 12, 38, 23, 799, DateTimeKind.Local).AddTicks(3696));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 9, 12, 29, 45, 409, DateTimeKind.Local).AddTicks(4176),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 9, 12, 38, 23, 799, DateTimeKind.Local).AddTicks(4815));

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
    }
}

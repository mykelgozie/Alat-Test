using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OtpAPI.Migrations
{
    public partial class Expiresin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiresIn",
                table: "Otps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "Otps",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiresIn",
                table: "Otps");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "Otps");
        }
    }
}

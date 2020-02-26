using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalRecords.API.Migrations
{
    public partial class AddedLastDateOfService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnticipatedDestructionDate",
                table: "Files");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Files",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDateOfService",
                table: "Clients",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "LastDateOfService",
                table: "Clients");

            migrationBuilder.AddColumn<DateTime>(
                name: "AnticipatedDestructionDate",
                table: "Files",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

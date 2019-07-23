using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalRecords.API.Migrations
{
    public partial class AnotherModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Files");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Boxes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "Boxes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "To",
                table: "Boxes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Boxes");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Boxes");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Boxes");

            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "Files",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "To",
                table: "Files",
                nullable: true);
        }
    }
}

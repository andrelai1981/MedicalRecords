using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalRecords.API.Migrations
{
    public partial class RemoveUnecessaryColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Files");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Files",
                nullable: false,
                defaultValue: 0);
        }
    }
}

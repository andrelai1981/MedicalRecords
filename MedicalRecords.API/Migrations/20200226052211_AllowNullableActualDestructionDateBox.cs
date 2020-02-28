using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalRecords.API.Migrations
{
    public partial class AllowNullableActualDestructionDateBox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualDestructionDate",
                table: "Boxes",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualDestructionDate",
                table: "Boxes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}

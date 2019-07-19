using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalRecords.API.Migrations
{
    public partial class AddedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Box_County_CountyId",
                table: "Box");

            migrationBuilder.DropForeignKey(
                name: "FK_Box_Department_DepartmentId",
                table: "Box");

            migrationBuilder.DropForeignKey(
                name: "FK_File_Box_BoxId",
                table: "File");

            migrationBuilder.DropForeignKey(
                name: "FK_File_Client_ClientId",
                table: "File");

            migrationBuilder.DropPrimaryKey(
                name: "PK_File",
                table: "File");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_County",
                table: "County");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Box",
                table: "Box");

            migrationBuilder.RenameTable(
                name: "File",
                newName: "Files");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "County",
                newName: "Counties");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.RenameTable(
                name: "Box",
                newName: "Boxes");

            migrationBuilder.RenameIndex(
                name: "IX_File_ClientId",
                table: "Files",
                newName: "IX_Files_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_File_BoxId",
                table: "Files",
                newName: "IX_Files_BoxId");

            migrationBuilder.RenameIndex(
                name: "IX_Box_DepartmentId",
                table: "Boxes",
                newName: "IX_Boxes_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Box_CountyId",
                table: "Boxes",
                newName: "IX_Boxes_CountyId");

            migrationBuilder.AddColumn<bool>(
                name: "Destroyed",
                table: "Files",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "BarcodeNum",
                table: "Boxes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "Destroyed",
                table: "Boxes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Files",
                table: "Files",
                column: "FileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Counties",
                table: "Counties",
                column: "CountyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boxes",
                table: "Boxes",
                column: "BoxId");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Boxes_Counties_CountyId",
                table: "Boxes",
                column: "CountyId",
                principalTable: "Counties",
                principalColumn: "CountyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Boxes_Departments_DepartmentId",
                table: "Boxes",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Boxes_BoxId",
                table: "Files",
                column: "BoxId",
                principalTable: "Boxes",
                principalColumn: "BoxId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Clients_ClientId",
                table: "Files",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Counties_CountyId",
                table: "Boxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Departments_DepartmentId",
                table: "Boxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Boxes_BoxId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Clients_ClientId",
                table: "Files");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
                table: "Files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Counties",
                table: "Counties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boxes",
                table: "Boxes");

            migrationBuilder.DropColumn(
                name: "Destroyed",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "BarcodeNum",
                table: "Boxes");

            migrationBuilder.DropColumn(
                name: "Destroyed",
                table: "Boxes");

            migrationBuilder.RenameTable(
                name: "Files",
                newName: "File");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameTable(
                name: "Counties",
                newName: "County");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.RenameTable(
                name: "Boxes",
                newName: "Box");

            migrationBuilder.RenameIndex(
                name: "IX_Files_ClientId",
                table: "File",
                newName: "IX_File_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Files_BoxId",
                table: "File",
                newName: "IX_File_BoxId");

            migrationBuilder.RenameIndex(
                name: "IX_Boxes_DepartmentId",
                table: "Box",
                newName: "IX_Box_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Boxes_CountyId",
                table: "Box",
                newName: "IX_Box_CountyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_File",
                table: "File",
                column: "FileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_County",
                table: "County",
                column: "CountyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Box",
                table: "Box",
                column: "BoxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Box_County_CountyId",
                table: "Box",
                column: "CountyId",
                principalTable: "County",
                principalColumn: "CountyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Box_Department_DepartmentId",
                table: "Box",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_File_Box_BoxId",
                table: "File",
                column: "BoxId",
                principalTable: "Box",
                principalColumn: "BoxId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_File_Client_ClientId",
                table: "File",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

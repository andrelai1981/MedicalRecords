﻿// <auto-generated />
using System;
using MedicalRecords.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MedicalRecords.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200220060534_AddedLastDateOfService")]
    partial class AddedLastDateOfService
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MedicalRecords.API.Models.Box", b =>
                {
                    b.Property<int>("BoxId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ActualDestructionDate");

                    b.Property<long>("BarcodeNum");

                    b.Property<int?>("CountyId");

                    b.Property<int?>("DepartmentId");

                    b.Property<string>("Description");

                    b.Property<bool>("Destroyed");

                    b.Property<string>("From");

                    b.Property<string>("To");

                    b.HasKey("BoxId");

                    b.HasIndex("CountyId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Boxes");
                });

            modelBuilder.Entity("MedicalRecords.API.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOB");

                    b.Property<string>("FirstName");

                    b.Property<DateTime>("LastDateOfService");

                    b.Property<string>("LastName");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("MedicalRecords.API.Models.County", b =>
                {
                    b.Property<int>("CountyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountyName");

                    b.HasKey("CountyId");

                    b.ToTable("Counties");
                });

            modelBuilder.Entity("MedicalRecords.API.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("MedicalRecords.API.Models.File", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ActualDestructionDate");

                    b.Property<int?>("BoxId");

                    b.Property<int?>("ClientId");

                    b.Property<string>("Description");

                    b.Property<bool>("Destroyed");

                    b.Property<int>("MyProperty");

                    b.HasKey("FileId");

                    b.HasIndex("BoxId");

                    b.HasIndex("ClientId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("MedicalRecords.API.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MedicalRecords.API.Models.Box", b =>
                {
                    b.HasOne("MedicalRecords.API.Models.County", "County")
                        .WithMany("Box")
                        .HasForeignKey("CountyId");

                    b.HasOne("MedicalRecords.API.Models.Department", "Department")
                        .WithMany("Box")
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("MedicalRecords.API.Models.File", b =>
                {
                    b.HasOne("MedicalRecords.API.Models.Box", "Box")
                        .WithMany("Files")
                        .HasForeignKey("BoxId");

                    b.HasOne("MedicalRecords.API.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");
                });
#pragma warning restore 612, 618
        }
    }
}

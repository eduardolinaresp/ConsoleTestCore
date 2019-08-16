﻿// <auto-generated />
using ConsoleTestCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleDemoApp.Migrations
{
    [DbContext(typeof(BDContext))]
    [Migration("20190815185900_initial_create")]
    partial class initial_create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsoleTestCore.Models.Student", b =>
                {
                    b.Property<int>("NroStudent")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cargo");

                    b.Property<string>("Clase");

                    b.Property<string>("IdStudent");

                    b.Property<string>("Nombre");

                    b.Property<string>("Password");

                    b.HasKey("NroStudent");

                    b.ToTable("TblStudents");
                });
#pragma warning restore 612, 618
        }
    }
}
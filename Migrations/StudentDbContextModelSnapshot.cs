﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Phonebook.Data;

#nullable disable

namespace Phonebook.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    partial class StudentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Phonebook.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Phonebook.Models.Score", b =>
                {
                    b.Property<int>("Course_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Course_id"));

                    b.Property<decimal>("CA_1")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("CA_2")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("CA_3")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Exam_score")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Matric_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Semester")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Course_id");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("Phonebook.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Admission_date")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<string>("Admission_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Course_of_study")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Date_of_birth")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Faculty")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("First_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Home_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Middle_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}

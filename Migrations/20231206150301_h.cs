﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phonebook.Migrations
{
    /// <inheritdoc />
    public partial class h : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Course_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Matric_number = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    CA_1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CA_2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CA_3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Exam_score = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    First_name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Middle_name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Last_name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Admission_number = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Admission_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Home_address = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Faculty = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Course_of_study = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Phone_number = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}

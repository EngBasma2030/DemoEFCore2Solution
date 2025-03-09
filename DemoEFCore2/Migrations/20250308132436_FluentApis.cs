using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEFCore2.Migrations
{
    /// <inheritdoc />
    public partial class FluentApis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.RenameColumn(
                name: "Email",
                schema: "dbo",
                table: "Employees",
                newName: "EmpEmail");

            migrationBuilder.AlterColumn<string>(
                name: "EmpEmail",
                schema: "dbo",
                table: "Employees",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "dbo",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "cairo");

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "Sales",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 10"),
                    DepartmentNAme = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, defaultValue: "HR"),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DeptId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments",
                schema: "Sales");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "dbo",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmpEmail",
                schema: "dbo",
                table: "Employees",
                newName: "Email");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");
        }
    }
}

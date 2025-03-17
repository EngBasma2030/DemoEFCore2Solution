using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEFCore2.Migrations
{
    /// <inheritdoc />
    public partial class OneToOneTotalAndOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Departments",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "Departments",
                newName: "DepartmentNAme");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "CreationDate",
                schema: "dbo",
                table: "Departments",
                type: "date",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                schema: "dbo",
                table: "Departments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "10, 10")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentNAme",
                schema: "dbo",
                table: "Departments",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                defaultValue: "HR",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DepatmentManagerId",
                schema: "dbo",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepatmentManagerId",
                schema: "dbo",
                table: "Departments",
                column: "DepatmentManagerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_DepatmentManagerId",
                schema: "dbo",
                table: "Departments",
                column: "DepatmentManagerId",
                principalSchema: "dbo",
                principalTable: "Employees",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_DepatmentManagerId",
                schema: "dbo",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepatmentManagerId",
                schema: "dbo",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DepatmentManagerId",
                schema: "dbo",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "Departments",
                schema: "dbo",
                newName: "Departments");

            migrationBuilder.RenameColumn(
                name: "DepartmentNAme",
                table: "Departments",
                newName: "Name");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "CreationDate",
                table: "Departments",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Departments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "10, 10");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldDefaultValue: "HR");
        }
    }
}

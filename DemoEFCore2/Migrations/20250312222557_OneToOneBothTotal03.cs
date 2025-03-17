using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEFCore2.Migrations
{
    /// <inheritdoc />
    public partial class OneToOneBothTotal03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_DepatmentManagerId",
                schema: "dbo",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "dbo",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                schema: "dbo",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                schema: "dbo",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                schema: "dbo",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                schema: "dbo",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                schema: "dbo",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                schema: "dbo",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_DepatmentManagerId",
                schema: "dbo",
                table: "Departments",
                column: "DepatmentManagerId",
                principalSchema: "dbo",
                principalTable: "Employees",
                principalColumn: "EmpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_DepatmentManagerId",
                schema: "dbo",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Address_City",
                schema: "dbo",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                schema: "dbo",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                schema: "dbo",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Address_City",
                schema: "dbo",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                schema: "dbo",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                schema: "dbo",
                table: "Departments");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "dbo",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "cairo");

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
    }
}

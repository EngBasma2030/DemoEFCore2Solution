using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEFCore2.Migrations
{
    /// <inheritdoc />
    public partial class changeInEmpEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmpEmail",
                schema: "dbo",
                table: "Employees",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmpEmail",
                schema: "dbo",
                table: "Employees",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);
        }
    }
}

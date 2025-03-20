using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEFCore2.Migrations
{
    /// <inheritdoc />
    public partial class CreateView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create View EmployeeDepartmentView
                                   with Encryption
                                   As
                                   Select E.EmpId EmpId , E.Name EmpName , D.DepartmentId DeptId , D.DepartmentNAme DeptName
                                   From Employees E , Departments D
                                   where D.DepartmentId = E.DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Drop View EmployeeDepartmentView");
        }
    }
}

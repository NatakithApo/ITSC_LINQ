using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItscEf.Migrations
{
    public partial class SEED_TblDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblDepartments",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Office" });

            migrationBuilder.InsertData(
                table: "TblDepartments",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Production" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblDepartments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TblDepartments",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

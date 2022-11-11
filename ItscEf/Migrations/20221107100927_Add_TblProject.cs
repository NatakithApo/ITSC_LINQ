using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItscEf.Migrations
{
    public partial class Add_TblProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblEmployeeTblProject",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEmployeeTblProject", x => new { x.EmployeesId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_TblEmployeeTblProject_TblEmployee_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "TblEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblEmployeeTblProject_TblProject_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "TblProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblEmployeeTblProject_ProjectsId",
                table: "TblEmployeeTblProject",
                column: "ProjectsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblEmployeeTblProject");

            migrationBuilder.DropTable(
                name: "TblProject");
        }
    }
}

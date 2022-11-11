using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItscEf.Migrations
{
    public partial class Add_TblPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblPosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblPosition_TblDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "TblDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblPosition_DepartmentId",
                table: "TblPosition",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblPosition");
        }
    }
}

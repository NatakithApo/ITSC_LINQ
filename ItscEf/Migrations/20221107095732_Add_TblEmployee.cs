using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItscEf.Migrations
{
    public partial class Add_TblEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<float>(type: "real", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblEmployee_TblPosition_PositionId",
                        column: x => x.PositionId,
                        principalTable: "TblPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblEmployee_PositionId",
                table: "TblEmployee",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblEmployee");
        }
    }
}

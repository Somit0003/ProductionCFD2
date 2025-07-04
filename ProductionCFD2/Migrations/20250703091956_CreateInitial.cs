using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductionCFD2.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Material_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Material_Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Material_Id);
                });

            migrationBuilder.CreateTable(
                name: "ShiftIncharges",
                columns: table => new
                {
                    ShiftIncharge_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftIncharge_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftIncharges", x => x.ShiftIncharge_Id);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Shift_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shift_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Shift_Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionTables",
                columns: table => new
                {
                    Production_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Production_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Shift_Id = table.Column<int>(type: "int", nullable: false),
                    Material_Id = table.Column<int>(type: "int", nullable: false),
                    Material_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Input_Batch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total_Weight = table.Column<int>(type: "int", nullable: false),
                    Total_Input = table.Column<int>(type: "int", nullable: false),
                    Rolling_Plan_Size = table.Column<int>(type: "int", nullable: false),
                    Grinding_Loss = table.Column<int>(type: "int", nullable: false),
                    Grinding_Wheel = table.Column<int>(type: "int", nullable: false),
                    EndCut = table.Column<int>(type: "int", nullable: false),
                    Sample_Loss = table.Column<int>(type: "int", nullable: false),
                    Finish_Weight = table.Column<int>(type: "int", nullable: false),
                    Yield = table.Column<int>(type: "int", nullable: false),
                    ShiftIncharge_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionTables", x => x.Production_Id);
                    table.ForeignKey(
                        name: "FK_ProductionTables_Materials_Material_Id",
                        column: x => x.Material_Id,
                        principalTable: "Materials",
                        principalColumn: "Material_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionTables_ShiftIncharges_ShiftIncharge_Id",
                        column: x => x.ShiftIncharge_Id,
                        principalTable: "ShiftIncharges",
                        principalColumn: "ShiftIncharge_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionTables_Shifts_Shift_Id",
                        column: x => x.Shift_Id,
                        principalTable: "Shifts",
                        principalColumn: "Shift_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTables_Material_Id",
                table: "ProductionTables",
                column: "Material_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTables_Shift_Id",
                table: "ProductionTables",
                column: "Shift_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTables_ShiftIncharge_Id",
                table: "ProductionTables",
                column: "ShiftIncharge_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionTables");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "ShiftIncharges");

            migrationBuilder.DropTable(
                name: "Shifts");
        }
    }
}

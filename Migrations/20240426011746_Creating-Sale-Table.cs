using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarQuery__Test.Migrations
{
    /// <inheritdoc />
    public partial class CreatingSaleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    IdCar = table.Column<int>(type: "int", nullable: false),
                    IdReseller = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Cars_IdCar",
                        column: x => x.IdCar,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Persons_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Resellers_IdReseller",
                        column: x => x.IdReseller,
                        principalTable: "Resellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_IdCar",
                table: "Sales",
                column: "IdCar");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_IdPerson",
                table: "Sales",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_IdReseller",
                table: "Sales",
                column: "IdReseller");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}

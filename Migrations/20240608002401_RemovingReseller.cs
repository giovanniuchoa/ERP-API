using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarQuery__Test.Migrations
{
    /// <inheritdoc />
    public partial class RemovingReseller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    idCar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    color = table.Column<byte>(type: "tinyint", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.idCar);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birth = table.Column<DateOnly>(type: "date", nullable: false),
                    sex = table.Column<byte>(type: "tinyint", nullable: false),
                    userType = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.idUser);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    idSale = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_IdClient = table.Column<int>(type: "int", nullable: false),
                    Fk_IdSeller = table.Column<int>(type: "int", nullable: false),
                    Fk_IdCar = table.Column<int>(type: "int", nullable: false),
                    DthRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.idSale);
                    table.ForeignKey(
                        name: "FK_Sales_Cars_Fk_IdCar",
                        column: x => x.Fk_IdCar,
                        principalTable: "Cars",
                        principalColumn: "idCar");
                    table.ForeignKey(
                        name: "FK_Sales_Users_Fk_IdClient",
                        column: x => x.Fk_IdClient,
                        principalTable: "Users",
                        principalColumn: "idUser");
                    table.ForeignKey(
                        name: "FK_Sales_Users_Fk_IdSeller",
                        column: x => x.Fk_IdSeller,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Fk_IdCar",
                table: "Sales",
                column: "Fk_IdCar");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Fk_IdClient",
                table: "Sales",
                column: "Fk_IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Fk_IdSeller",
                table: "Sales",
                column: "Fk_IdSeller");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

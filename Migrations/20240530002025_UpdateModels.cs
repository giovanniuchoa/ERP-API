using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarQuery__Test.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
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
                name: "Resellers",
                columns: table => new
                {
                    idReseller = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameReseller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classification = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resellers", x => x.idReseller);
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
                    fk_idClient = table.Column<int>(type: "int", nullable: false),
                    clientidUser = table.Column<int>(type: "int", nullable: true),
                    fk_idSeller = table.Column<int>(type: "int", nullable: false),
                    selleridUser = table.Column<int>(type: "int", nullable: true),
                    fk_idCar = table.Column<int>(type: "int", nullable: false),
                    caridCar = table.Column<int>(type: "int", nullable: true),
                    fk_idReseller = table.Column<int>(type: "int", nullable: false),
                    reselleridReseller = table.Column<int>(type: "int", nullable: true),
                    DthRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.idSale);
                    table.ForeignKey(
                        name: "FK_Sales_Cars_caridCar",
                        column: x => x.caridCar,
                        principalTable: "Cars",
                        principalColumn: "idCar");
                    table.ForeignKey(
                        name: "FK_Sales_Resellers_reselleridReseller",
                        column: x => x.reselleridReseller,
                        principalTable: "Resellers",
                        principalColumn: "idReseller");
                    table.ForeignKey(
                        name: "FK_Sales_Users_clientidUser",
                        column: x => x.clientidUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                    table.ForeignKey(
                        name: "FK_Sales_Users_selleridUser",
                        column: x => x.selleridUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_caridCar",
                table: "Sales",
                column: "caridCar");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_clientidUser",
                table: "Sales",
                column: "clientidUser");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_reselleridReseller",
                table: "Sales",
                column: "reselleridReseller");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_selleridUser",
                table: "Sales",
                column: "selleridUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Resellers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

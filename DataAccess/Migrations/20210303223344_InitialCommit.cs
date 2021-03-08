using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    Precio = table.Column<decimal>(type: "MONEY", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogErrores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Error = table.Column<string>(type: "VARCHAR(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogErrores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LibroId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Cantidad = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Libros_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistorialMovimientosStocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StockId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    StockAnterior = table.Column<int>(type: "INT", nullable: false),
                    StockNuevo = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialMovimientosStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorialMovimientosStocks_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialMovimientosStocks_StockId",
                table: "HistorialMovimientosStocks",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_LibroId",
                table: "Stocks",
                column: "LibroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialMovimientosStocks");

            migrationBuilder.DropTable(
                name: "LogErrores");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}

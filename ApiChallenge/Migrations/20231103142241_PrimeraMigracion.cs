using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiChallenge.Migrations
{
    public partial class PrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TipoProductoId = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    FechaCompra = table.Column<DateTime>(type: "date", nullable: true),
                    EstadoProducto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "TiposProducto",
                columns: table => new
                {
                    TipoProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TiposPro__FB00758A8F6A2234", x => x.TipoProductoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "TiposProducto");
        }
    }
}

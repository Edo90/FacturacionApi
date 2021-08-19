using Microsoft.EntityFrameworkCore.Migrations;

namespace FacturacionApi.Migrations
{
    public partial class FacturacionDetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturaciones_Articulos_ArticuloId",
                table: "Facturaciones");

            migrationBuilder.DropIndex(
                name: "IX_Facturaciones_ArticuloId",
                table: "Facturaciones");

            migrationBuilder.DropColumn(
                name: "ArticuloId",
                table: "Facturaciones");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Facturaciones");

            migrationBuilder.DropColumn(
                name: "PrecioUnitario",
                table: "Facturaciones");

            migrationBuilder.CreateTable(
                name: "FacturacionDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FacturacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturacionDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacturacionDetalle_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturacionDetalle_Facturaciones_FacturacionId",
                        column: x => x.FacturacionId,
                        principalTable: "Facturaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacturacionDetalle_ArticuloId",
                table: "FacturacionDetalle",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturacionDetalle_FacturacionId",
                table: "FacturacionDetalle",
                column: "FacturacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacturacionDetalle");

            migrationBuilder.AddColumn<int>(
                name: "ArticuloId",
                table: "Facturaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "Facturaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioUnitario",
                table: "Facturaciones",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Facturaciones_ArticuloId",
                table: "Facturaciones",
                column: "ArticuloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturaciones_Articulos_ArticuloId",
                table: "Facturaciones",
                column: "ArticuloId",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

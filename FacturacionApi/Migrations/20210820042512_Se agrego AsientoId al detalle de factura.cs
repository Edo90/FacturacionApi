using Microsoft.EntityFrameworkCore.Migrations;

namespace FacturacionApi.Migrations
{
    public partial class SeagregoAsientoIdaldetalledefactura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AsientoId",
                table: "FacturacionDetalle",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AsientoId",
                table: "FacturacionDetalle");
        }
    }
}

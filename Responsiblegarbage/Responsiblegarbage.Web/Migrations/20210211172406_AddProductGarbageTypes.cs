using Microsoft.EntityFrameworkCore.Migrations;

namespace Responsiblegarbage.Web.Migrations
{
    public partial class AddProductGarbageTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductGarbageTypes",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGarbageTypes", x => new { x.ProductId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_ProductGarbageTypes_GarbageTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "GarbageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductGarbageTypes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductGarbageTypes_TypeId",
                table: "ProductGarbageTypes",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductGarbageTypes");
        }
    }
}

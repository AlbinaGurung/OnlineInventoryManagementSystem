using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement_2.Migrations
{
    /// <inheritdoc />
    public partial class somechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_Categories_CategoryId",
                table: "PurchaseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_Unit_UnitId",
                table: "PurchaseDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseDetails_CategoryId",
                table: "PurchaseDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseDetails_UnitId",
                table: "PurchaseDetails");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "PurchaseDetails");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "PurchaseDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "PurchaseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "PurchaseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_CategoryId",
                table: "PurchaseDetails",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_UnitId",
                table: "PurchaseDetails",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_Categories_CategoryId",
                table: "PurchaseDetails",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_Unit_UnitId",
                table: "PurchaseDetails",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id");
        }
    }
}

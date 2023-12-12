using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement_2.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "PurchaseDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseId1",
                table: "PurchaseDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_PurchaseId1",
                table: "PurchaseDetails",
                column: "PurchaseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_Purchases_PurchaseId1",
                table: "PurchaseDetails",
                column: "PurchaseId1",
                principalTable: "Purchases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_Purchases_PurchaseId1",
                table: "PurchaseDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseDetails_PurchaseId1",
                table: "PurchaseDetails");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "PurchaseDetails");

            migrationBuilder.DropColumn(
                name: "PurchaseId1",
                table: "PurchaseDetails");
        }
    }
}

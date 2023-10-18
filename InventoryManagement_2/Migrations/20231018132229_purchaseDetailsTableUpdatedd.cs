using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement_2.Migrations
{
    /// <inheritdoc />
    public partial class purchaseDetailsTableUpdatedd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_Purchases_PurchaseId",
                table: "PurchaseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_in_prod_ProductId",
                table: "PurchaseDetails");

            migrationBuilder.DeleteData(
                table: "PurchaseDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1);

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
                name: "FK_PurchaseDetails_Purchases_PurchaseId",
                table: "PurchaseDetails",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_Unit_UnitId",
                table: "PurchaseDetails",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_in_prod_ProductId",
                table: "PurchaseDetails",
                column: "ProductId",
                principalTable: "in_prod",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_Categories_CategoryId",
                table: "PurchaseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_Purchases_PurchaseId",
                table: "PurchaseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_Unit_UnitId",
                table: "PurchaseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_in_prod_ProductId",
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

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Tanuja" });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Piece" });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "PurchaseDate", "SuppliersId", "TotalAmount" },
                values: new object[] { 1, new DateTime(2023, 10, 18, 2, 28, 19, 863, DateTimeKind.Local).AddTicks(9096), 1, 7500m });

            migrationBuilder.InsertData(
                table: "PurchaseDetails",
                columns: new[] { "Id", "ProductId", "PurchaseId", "Rate", "TotalAmount", "quantity" },
                values: new object[] { 1, 10, 1, 50m, 7500m, 150m });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_Purchases_PurchaseId",
                table: "PurchaseDetails",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_in_prod_ProductId",
                table: "PurchaseDetails",
                column: "ProductId",
                principalTable: "in_prod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

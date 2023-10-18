using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement_2.Migrations
{
    /// <inheritdoc />
    public partial class DataseedingInPurchaseTableandOthers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Tanuja" });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "PurchaseDate", "SuppliersId", "TotalAmount" },
                values: new object[] { 1, new DateTime(2023, 10, 18, 2, 28, 19, 863, DateTimeKind.Local).AddTicks(9096), 1, 7500m });

            migrationBuilder.InsertData(
                table: "PurchaseDetails",
                columns: new[] { "Id", "ProductId", "PurchaseId", "Rate", "TotalAmount", "quantity" },
                values: new object[] { 1, 10, 1, 50m, 7500m, 150m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PurchaseDetails",
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
        }
    }
}

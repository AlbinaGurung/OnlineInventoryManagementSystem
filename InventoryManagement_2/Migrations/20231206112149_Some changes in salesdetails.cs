using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement_2.Migrations
{
    /// <inheritdoc />
    public partial class Somechangesinsalesdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "inv_salesDetails",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "discount",
                table: "inv_salesDetails",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "NetAmount",
                table: "inv_salesDetails",
                newName: "TotalAmount");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                table: "inv_sales",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "inv_salesDetails",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "inv_salesDetails",
                newName: "discount");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "inv_salesDetails",
                newName: "NetAmount");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                table: "inv_sales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

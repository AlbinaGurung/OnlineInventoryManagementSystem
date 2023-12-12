using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement_2.Migrations
{
    /// <inheritdoc />
    public partial class QuantityAddedOnProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "in_prod",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "in_prod");
        }
    }
}

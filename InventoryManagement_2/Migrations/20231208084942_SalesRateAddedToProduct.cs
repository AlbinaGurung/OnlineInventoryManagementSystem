using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement_2.Migrations
{
    /// <inheritdoc />
    public partial class SalesRateAddedToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalesPrice",
                table: "in_prod",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesPrice",
                table: "in_prod");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EInvoice.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModelModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "Taxs");

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                table: "ItemTax",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "ItemTax");

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                table: "Taxs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

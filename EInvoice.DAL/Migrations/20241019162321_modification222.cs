using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EInvoice.DAL.Migrations
{
    /// <inheritdoc />
    public partial class modification222 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItemTaxes_InvoiceItems_InvoiceItemID",
                table: "InvoiceItemTaxes");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItemTaxes_Taxs_TaxId",
                table: "InvoiceItemTaxes");

            migrationBuilder.AlterColumn<int>(
                name: "TaxId",
                table: "InvoiceItemTaxes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceItemID",
                table: "InvoiceItemTaxes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItemTaxes_InvoiceItems_InvoiceItemID",
                table: "InvoiceItemTaxes",
                column: "InvoiceItemID",
                principalTable: "InvoiceItems",
                principalColumn: "InvoiceItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItemTaxes_Taxs_TaxId",
                table: "InvoiceItemTaxes",
                column: "TaxId",
                principalTable: "Taxs",
                principalColumn: "TaxID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItemTaxes_InvoiceItems_InvoiceItemID",
                table: "InvoiceItemTaxes");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItemTaxes_Taxs_TaxId",
                table: "InvoiceItemTaxes");

            migrationBuilder.AlterColumn<int>(
                name: "TaxId",
                table: "InvoiceItemTaxes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceItemID",
                table: "InvoiceItemTaxes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItemTaxes_InvoiceItems_InvoiceItemID",
                table: "InvoiceItemTaxes",
                column: "InvoiceItemID",
                principalTable: "InvoiceItems",
                principalColumn: "InvoiceItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItemTaxes_Taxs_TaxId",
                table: "InvoiceItemTaxes",
                column: "TaxId",
                principalTable: "Taxs",
                principalColumn: "TaxID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

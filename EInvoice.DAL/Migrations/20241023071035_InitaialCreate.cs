using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EInvoice.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitaialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Items_ItemId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItemTaxes_Taxs_TaxId",
                table: "InvoiceItemTaxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_CustomerID",
                table: "Invoices");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Items_ItemId",
                table: "InvoiceItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItemTaxes_Taxs_TaxId",
                table: "InvoiceItemTaxes",
                column: "TaxId",
                principalTable: "Taxs",
                principalColumn: "TaxID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Customers_CustomerID",
                table: "Invoices",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Items_ItemId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItemTaxes_Taxs_TaxId",
                table: "InvoiceItemTaxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_CustomerID",
                table: "Invoices");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Items_ItemId",
                table: "InvoiceItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItemTaxes_Taxs_TaxId",
                table: "InvoiceItemTaxes",
                column: "TaxId",
                principalTable: "Taxs",
                principalColumn: "TaxID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Customers_CustomerID",
                table: "Invoices",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID");
        }
    }
}

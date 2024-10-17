using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EInvoice.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItem_Invoices_InvoiceId",
                table: "InvoiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItem_Items_ItemId",
                table: "InvoiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItemTax_InvoiceItem_ItemInvoiceID",
                table: "InvoiceItemTax");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItemTax_Taxs_TaxId",
                table: "InvoiceItemTax");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceItemTax",
                table: "InvoiceItemTax");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceItem",
                table: "InvoiceItem");

            migrationBuilder.RenameTable(
                name: "InvoiceItemTax",
                newName: "InvoiceItemTaxes");

            migrationBuilder.RenameTable(
                name: "InvoiceItem",
                newName: "InvoiceItems");

            migrationBuilder.RenameColumn(
                name: "InvoiceCode",
                table: "Invoices",
                newName: "Code");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItemTax_TaxId",
                table: "InvoiceItemTaxes",
                newName: "IX_InvoiceItemTaxes_TaxId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItemTax_ItemInvoiceID",
                table: "InvoiceItemTaxes",
                newName: "IX_InvoiceItemTaxes_ItemInvoiceID");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItem_ItemId",
                table: "InvoiceItems",
                newName: "IX_InvoiceItems_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItem_InvoiceId",
                table: "InvoiceItems",
                newName: "IX_InvoiceItems_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceItemTaxes",
                table: "InvoiceItemTaxes",
                column: "InvoiceItemTaxID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceItems",
                table: "InvoiceItems",
                column: "ItemInvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoiceId",
                table: "InvoiceItems",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Items_ItemId",
                table: "InvoiceItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItemTaxes_InvoiceItems_ItemInvoiceID",
                table: "InvoiceItemTaxes",
                column: "ItemInvoiceID",
                principalTable: "InvoiceItems",
                principalColumn: "ItemInvoiceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItemTaxes_Taxs_TaxId",
                table: "InvoiceItemTaxes",
                column: "TaxId",
                principalTable: "Taxs",
                principalColumn: "TaxID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoiceId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Items_ItemId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItemTaxes_InvoiceItems_ItemInvoiceID",
                table: "InvoiceItemTaxes");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItemTaxes_Taxs_TaxId",
                table: "InvoiceItemTaxes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceItemTaxes",
                table: "InvoiceItemTaxes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceItems",
                table: "InvoiceItems");

            migrationBuilder.RenameTable(
                name: "InvoiceItemTaxes",
                newName: "InvoiceItemTax");

            migrationBuilder.RenameTable(
                name: "InvoiceItems",
                newName: "InvoiceItem");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Invoices",
                newName: "InvoiceCode");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItemTaxes_TaxId",
                table: "InvoiceItemTax",
                newName: "IX_InvoiceItemTax_TaxId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItemTaxes_ItemInvoiceID",
                table: "InvoiceItemTax",
                newName: "IX_InvoiceItemTax_ItemInvoiceID");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItems_ItemId",
                table: "InvoiceItem",
                newName: "IX_InvoiceItem_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItems_InvoiceId",
                table: "InvoiceItem",
                newName: "IX_InvoiceItem_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceItemTax",
                table: "InvoiceItemTax",
                column: "InvoiceItemTaxID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceItem",
                table: "InvoiceItem",
                column: "ItemInvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItem_Invoices_InvoiceId",
                table: "InvoiceItem",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItem_Items_ItemId",
                table: "InvoiceItem",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItemTax_InvoiceItem_ItemInvoiceID",
                table: "InvoiceItemTax",
                column: "ItemInvoiceID",
                principalTable: "InvoiceItem",
                principalColumn: "ItemInvoiceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItemTax_Taxs_TaxId",
                table: "InvoiceItemTax",
                column: "TaxId",
                principalTable: "Taxs",
                principalColumn: "TaxID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

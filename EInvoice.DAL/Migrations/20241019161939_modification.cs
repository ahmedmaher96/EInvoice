using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EInvoice.DAL.Migrations
{
    /// <inheritdoc />
    public partial class modification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoiceId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Items_ItemId",
                table: "InvoiceItems");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "InvoiceItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "InvoiceItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoiceId",
                table: "InvoiceItems",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Items_ItemId",
                table: "InvoiceItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemID");
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

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "InvoiceItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "InvoiceItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
        }
    }
}

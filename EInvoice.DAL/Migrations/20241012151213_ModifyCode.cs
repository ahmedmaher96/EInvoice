using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EInvoice.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModifyCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaxCode",
                table: "Taxs",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "ItemCode",
                table: "Items",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "CustomerCode",
                table: "Customers",
                newName: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Taxs",
                newName: "TaxCode");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Items",
                newName: "ItemCode");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Customers",
                newName: "CustomerCode");
        }
    }
}

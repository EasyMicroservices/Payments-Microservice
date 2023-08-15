using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyMicroservices.PaymentsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class fixbog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Service_ServiceId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceStatusHistory_Invoice_InvoiceId",
                table: "InvoiceStatusHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Invoice_InvoiceId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceAddress_Service_ServiceId",
                table: "ServiceAddress");

            migrationBuilder.DropIndex(
                name: "IX_ServiceAddress_ServiceId",
                table: "ServiceAddress");

            migrationBuilder.DropIndex(
                name: "IX_Product_InvoiceId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceStatusHistory_InvoiceId",
                table: "InvoiceStatusHistory");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_ServiceId",
                table: "Invoice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ServiceAddress_ServiceId",
                table: "ServiceAddress",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_InvoiceId",
                table: "Product",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceStatusHistory_InvoiceId",
                table: "InvoiceStatusHistory",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ServiceId",
                table: "Invoice",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Service_ServiceId",
                table: "Invoice",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceStatusHistory_Invoice_InvoiceId",
                table: "InvoiceStatusHistory",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Invoice_InvoiceId",
                table: "Product",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceAddress_Service_ServiceId",
                table: "ServiceAddress",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

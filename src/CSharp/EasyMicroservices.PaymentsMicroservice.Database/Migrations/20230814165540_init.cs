using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyMicroservices.PaymentsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceAddress",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceAddress_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceStatusHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceStatusHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceStatusHistory_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CreationDateTime",
                table: "Invoice",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_DeletedDateTime",
                table: "Invoice",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_IsDeleted",
                table: "Invoice",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ModificationDateTime",
                table: "Invoice",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ServiceId",
                table: "Invoice",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_UniqueIdentity",
                table: "Invoice",
                column: "UniqueIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceStatusHistory_CreationDateTime",
                table: "InvoiceStatusHistory",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceStatusHistory_DeletedDateTime",
                table: "InvoiceStatusHistory",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceStatusHistory_InvoiceId",
                table: "InvoiceStatusHistory",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceStatusHistory_IsDeleted",
                table: "InvoiceStatusHistory",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceStatusHistory_ModificationDateTime",
                table: "InvoiceStatusHistory",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceStatusHistory_UniqueIdentity",
                table: "InvoiceStatusHistory",
                column: "UniqueIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CreationDateTime",
                table: "Product",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Product_DeletedDateTime",
                table: "Product",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Product_InvoiceId",
                table: "Product",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IsDeleted",
                table: "Product",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ModificationDateTime",
                table: "Product",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UniqueIdentity",
                table: "Product",
                column: "UniqueIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_Service_CreationDateTime",
                table: "Service",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Service_DeletedDateTime",
                table: "Service",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Service_IsDeleted",
                table: "Service",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ModificationDateTime",
                table: "Service",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Service_UniqueIdentity",
                table: "Service",
                column: "UniqueIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAddress_CreationDateTime",
                table: "ServiceAddress",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAddress_DeletedDateTime",
                table: "ServiceAddress",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAddress_IsDeleted",
                table: "ServiceAddress",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAddress_ModificationDateTime",
                table: "ServiceAddress",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAddress_ServiceId",
                table: "ServiceAddress",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAddress_UniqueIdentity",
                table: "ServiceAddress",
                column: "UniqueIdentity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceStatusHistory");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ServiceAddress");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Service");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice_Generator.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateinvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_FromAddresses_FromId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_ToAddresses_ToId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_Invoices_InvoiceId",
                table: "Work");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_FromId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ToId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "FromId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ToId",
                table: "Invoices");

            migrationBuilder.AlterColumn<Guid>(
                name: "InvoiceId",
                table: "Work",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressFromEmail",
                table: "Invoices",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressFromLine1",
                table: "Invoices",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressFromLine2",
                table: "Invoices",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressFromName",
                table: "Invoices",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressFromPhone",
                table: "Invoices",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressFromPostCode",
                table: "Invoices",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressToLine1",
                table: "Invoices",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressToLine2",
                table: "Invoices",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressToName",
                table: "Invoices",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressToPostCode",
                table: "Invoices",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Invoices_InvoiceId",
                table: "Work",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Work_Invoices_InvoiceId",
                table: "Work");

            migrationBuilder.DropColumn(
                name: "AddressFromEmail",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "AddressFromLine1",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "AddressFromLine2",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "AddressFromName",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "AddressFromPhone",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "AddressFromPostCode",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "AddressToLine1",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "AddressToLine2",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "AddressToName",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "AddressToPostCode",
                table: "Invoices");

            migrationBuilder.AlterColumn<Guid>(
                name: "InvoiceId",
                table: "Work",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "FromId",
                table: "Invoices",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ToId",
                table: "Invoices",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_FromId",
                table: "Invoices",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ToId",
                table: "Invoices",
                column: "ToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_FromAddresses_FromId",
                table: "Invoices",
                column: "FromId",
                principalTable: "FromAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_ToAddresses_ToId",
                table: "Invoices",
                column: "ToId",
                principalTable: "ToAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Invoices_InvoiceId",
                table: "Work",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id");
        }
    }
}

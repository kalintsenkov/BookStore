#nullable disable
namespace BookStore.Infrastructure.Common.Persistence.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

public partial class CustomerAddress : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Address_BillingAddress",
            table: "Customers");

        migrationBuilder.DropColumn(
            name: "Address_DeliveryAddress",
            table: "Customers");

        migrationBuilder.DropColumn(
            name: "FirstName",
            table: "Customers");

        migrationBuilder.DropColumn(
            name: "PhoneNumber_Number",
            table: "Customers");

        migrationBuilder.RenameColumn(
            name: "LastName",
            table: "Customers",
            newName: "Name");

        migrationBuilder.AlterColumn<string>(
            name: "UserId",
            table: "Customers",
            type: "nvarchar(450)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.CreateTable(
            name: "Address",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                State = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                PhoneNumber_Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                AddressId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Address", x => x.Id);
                table.ForeignKey(
                    name: "FK_Address_Customers_AddressId",
                    column: x => x.AddressId,
                    principalTable: "Customers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Customers_UserId",
            table: "Customers",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_Address_AddressId",
            table: "Address",
            column: "AddressId",
            unique: true,
            filter: "[AddressId] IS NOT NULL");

        migrationBuilder.AddForeignKey(
            name: "FK_Customers_AspNetUsers_UserId",
            table: "Customers",
            column: "UserId",
            principalTable: "AspNetUsers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Customers_AspNetUsers_UserId",
            table: "Customers");

        migrationBuilder.DropTable(
            name: "Address");

        migrationBuilder.DropIndex(
            name: "IX_Customers_UserId",
            table: "Customers");

        migrationBuilder.RenameColumn(
            name: "Name",
            table: "Customers",
            newName: "LastName");

        migrationBuilder.AlterColumn<string>(
            name: "UserId",
            table: "Customers",
            type: "nvarchar(max)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(450)");

        migrationBuilder.AddColumn<string>(
            name: "Address_BillingAddress",
            table: "Customers",
            type: "nvarchar(360)",
            maxLength: 360,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "Address_DeliveryAddress",
            table: "Customers",
            type: "nvarchar(360)",
            maxLength: 360,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "FirstName",
            table: "Customers",
            type: "nvarchar(120)",
            maxLength: 120,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "PhoneNumber_Number",
            table: "Customers",
            type: "nvarchar(20)",
            maxLength: 20,
            nullable: false,
            defaultValue: "");
    }
}
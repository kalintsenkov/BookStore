#nullable disable
namespace BookStore.Infrastructure.Common.Persistence.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

public partial class RenameCustomersTable : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey(
            name: "PK_Customer",
            table: "Customer");

        migrationBuilder.RenameTable(
            name: "Customer",
            newName: "Customers");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Customers",
            table: "Customers",
            column: "Id");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey(
            name: "PK_Customers",
            table: "Customers");

        migrationBuilder.RenameTable(
            name: "Customers",
            newName: "Customer");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Customer",
            table: "Customer",
            column: "Id");
    }
}
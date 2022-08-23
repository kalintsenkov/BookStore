#nullable disable
namespace BookStore.Infrastructure.Common.Persistence.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

public partial class OrderStatus : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "State_Value",
            table: "Orders",
            newName: "Status_Value");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "Status_Value",
            table: "Orders",
            newName: "State_Value");
    }
}
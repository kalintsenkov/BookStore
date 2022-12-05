#nullable disable
namespace BookStore.Infrastructure.Common.Persistence.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class BookImageUrl : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "ImageUrl",
            table: "SalesBooks",
            type: "nvarchar(2048)",
            maxLength: 2048,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "ImageUrl",
            table: "CatalogBooks",
            type: "nvarchar(2048)",
            maxLength: 2048,
            nullable: false,
            defaultValue: "");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "ImageUrl",
            table: "SalesBooks");

        migrationBuilder.DropColumn(
            name: "ImageUrl",
            table: "CatalogBooks");
    }
}
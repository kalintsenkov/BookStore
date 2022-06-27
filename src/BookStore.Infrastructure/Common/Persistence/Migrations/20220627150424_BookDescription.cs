#nullable disable
namespace BookStore.Infrastructure.Common.Persistence.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

public partial class BookDescription : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "Description",
            table: "Books",
            type: "nvarchar(1200)",
            maxLength: 1200,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AlterColumn<string>(
            name: "Description",
            table: "Authors",
            type: "nvarchar(1200)",
            maxLength: 1200,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(160)",
            oldMaxLength: 160);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Description",
            table: "Books");

        migrationBuilder.AlterColumn<string>(
            name: "Description",
            table: "Authors",
            type: "nvarchar(160)",
            maxLength: 160,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(1200)",
            oldMaxLength: 1200);
    }
}
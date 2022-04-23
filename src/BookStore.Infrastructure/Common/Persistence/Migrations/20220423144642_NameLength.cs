#nullable disable
namespace BookStore.Infrastructure.Common.Persistence.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

public partial class NameLength : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "Title",
            table: "Books",
            type: "nvarchar(120)",
            maxLength: 120,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(20)",
            oldMaxLength: 20);

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Authors",
            type: "nvarchar(120)",
            maxLength: 120,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(20)",
            oldMaxLength: 20);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "Title",
            table: "Books",
            type: "nvarchar(20)",
            maxLength: 20,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(120)",
            oldMaxLength: 120);

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Authors",
            type: "nvarchar(20)",
            maxLength: 20,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(120)",
            oldMaxLength: 120);
    }
}

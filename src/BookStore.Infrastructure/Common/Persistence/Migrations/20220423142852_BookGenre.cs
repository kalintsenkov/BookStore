#nullable disable
namespace BookStore.Infrastructure.Common.Persistence.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

public partial class BookGenre : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Books_Genres_GenreId",
            table: "Books");

        migrationBuilder.DropTable(
            name: "Genres");

        migrationBuilder.DropIndex(
            name: "IX_Books_GenreId",
            table: "Books");

        migrationBuilder.RenameColumn(
            name: "GenreId",
            table: "Books",
            newName: "Genre_Value");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "Genre_Value",
            table: "Books",
            newName: "GenreId");

        migrationBuilder.CreateTable(
            name: "Genres",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Description = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Genres", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Books_GenreId",
            table: "Books",
            column: "GenreId");

        migrationBuilder.AddForeignKey(
            name: "FK_Books_Genres_GenreId",
            table: "Books",
            column: "GenreId",
            principalTable: "Genres",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }
}

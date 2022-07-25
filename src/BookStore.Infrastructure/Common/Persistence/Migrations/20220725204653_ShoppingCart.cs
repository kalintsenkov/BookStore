#nullable disable
namespace BookStore.Infrastructure.Common.Persistence.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

public partial class ShoppingCart : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "ShoppingCarts",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                CustomerId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                table.ForeignKey(
                    name: "FK_ShoppingCarts_Customers_CustomerId",
                    column: x => x.CustomerId,
                    principalTable: "Customers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "ShoppingCartBooks",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                BookId = table.Column<int>(type: "int", nullable: false),
                Quantity = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ShoppingCartBooks", x => x.Id);
                table.ForeignKey(
                    name: "FK_ShoppingCartBooks_Books_BookId",
                    column: x => x.BookId,
                    principalTable: "Books",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_ShoppingCartBooks_ShoppingCarts_ShoppingCartId",
                    column: x => x.ShoppingCartId,
                    principalTable: "ShoppingCarts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_ShoppingCartBooks_BookId",
            table: "ShoppingCartBooks",
            column: "BookId");

        migrationBuilder.CreateIndex(
            name: "IX_ShoppingCartBooks_ShoppingCartId",
            table: "ShoppingCartBooks",
            column: "ShoppingCartId");

        migrationBuilder.CreateIndex(
            name: "IX_ShoppingCarts_CustomerId",
            table: "ShoppingCarts",
            column: "CustomerId",
            unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "ShoppingCartBooks");

        migrationBuilder.DropTable(
            name: "ShoppingCarts");
    }
}
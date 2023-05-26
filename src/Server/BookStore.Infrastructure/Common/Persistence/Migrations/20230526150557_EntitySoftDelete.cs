#nullable disable
namespace BookStore.Infrastructure.Common.Persistence.Migrations;

using System;
using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class EntitySoftDelete : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<DateTime>(
            name: "DeletedOn",
            table: "ShoppingCarts",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "ShoppingCarts",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<DateTime>(
            name: "DeletedOn",
            table: "ShoppingCartBooks",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "ShoppingCartBooks",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<DateTime>(
            name: "DeletedOn",
            table: "SalesBooks",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "SalesBooks",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<DateTime>(
            name: "DeletedOn",
            table: "Orders",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "Orders",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<DateTime>(
            name: "DeletedOn",
            table: "OrderedBooks",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "OrderedBooks",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<DateTime>(
            name: "DeletedOn",
            table: "Customers",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "Customers",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<DateTime>(
            name: "DeletedOn",
            table: "CatalogBooks",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "CatalogBooks",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<DateTime>(
            name: "DeletedOn",
            table: "Authors",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "Authors",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<DateTime>(
            name: "DeletedOn",
            table: "Addresses",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "Addresses",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.CreateIndex(
            name: "IX_ShoppingCarts_IsDeleted",
            table: "ShoppingCarts",
            column: "IsDeleted");

        migrationBuilder.CreateIndex(
            name: "IX_ShoppingCartBooks_IsDeleted",
            table: "ShoppingCartBooks",
            column: "IsDeleted");

        migrationBuilder.CreateIndex(
            name: "IX_SalesBooks_IsDeleted",
            table: "SalesBooks",
            column: "IsDeleted");

        migrationBuilder.CreateIndex(
            name: "IX_Orders_IsDeleted",
            table: "Orders",
            column: "IsDeleted");

        migrationBuilder.CreateIndex(
            name: "IX_OrderedBooks_IsDeleted",
            table: "OrderedBooks",
            column: "IsDeleted");

        migrationBuilder.CreateIndex(
            name: "IX_Customers_IsDeleted",
            table: "Customers",
            column: "IsDeleted");

        migrationBuilder.CreateIndex(
            name: "IX_CatalogBooks_IsDeleted",
            table: "CatalogBooks",
            column: "IsDeleted");

        migrationBuilder.CreateIndex(
            name: "IX_Authors_IsDeleted",
            table: "Authors",
            column: "IsDeleted");

        migrationBuilder.CreateIndex(
            name: "IX_Addresses_IsDeleted",
            table: "Addresses",
            column: "IsDeleted");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_ShoppingCarts_IsDeleted",
            table: "ShoppingCarts");

        migrationBuilder.DropIndex(
            name: "IX_ShoppingCartBooks_IsDeleted",
            table: "ShoppingCartBooks");

        migrationBuilder.DropIndex(
            name: "IX_SalesBooks_IsDeleted",
            table: "SalesBooks");

        migrationBuilder.DropIndex(
            name: "IX_Orders_IsDeleted",
            table: "Orders");

        migrationBuilder.DropIndex(
            name: "IX_OrderedBooks_IsDeleted",
            table: "OrderedBooks");

        migrationBuilder.DropIndex(
            name: "IX_Customers_IsDeleted",
            table: "Customers");

        migrationBuilder.DropIndex(
            name: "IX_CatalogBooks_IsDeleted",
            table: "CatalogBooks");

        migrationBuilder.DropIndex(
            name: "IX_Authors_IsDeleted",
            table: "Authors");

        migrationBuilder.DropIndex(
            name: "IX_Addresses_IsDeleted",
            table: "Addresses");

        migrationBuilder.DropColumn(
            name: "DeletedOn",
            table: "ShoppingCarts");

        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "ShoppingCarts");

        migrationBuilder.DropColumn(
            name: "DeletedOn",
            table: "ShoppingCartBooks");

        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "ShoppingCartBooks");

        migrationBuilder.DropColumn(
            name: "DeletedOn",
            table: "SalesBooks");

        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "SalesBooks");

        migrationBuilder.DropColumn(
            name: "DeletedOn",
            table: "Orders");

        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "Orders");

        migrationBuilder.DropColumn(
            name: "DeletedOn",
            table: "OrderedBooks");

        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "OrderedBooks");

        migrationBuilder.DropColumn(
            name: "DeletedOn",
            table: "Customers");

        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "Customers");

        migrationBuilder.DropColumn(
            name: "DeletedOn",
            table: "CatalogBooks");

        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "CatalogBooks");

        migrationBuilder.DropColumn(
            name: "DeletedOn",
            table: "Authors");

        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "Authors");

        migrationBuilder.DropColumn(
            name: "DeletedOn",
            table: "Addresses");

        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "Addresses");
    }
}
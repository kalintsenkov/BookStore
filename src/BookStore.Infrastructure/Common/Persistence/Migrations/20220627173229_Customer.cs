#nullable disable
namespace BookStore.Infrastructure.Common.Persistence.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

public partial class Customer : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Customer",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                FirstName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                LastName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Address_BillingAddress = table.Column<string>(type: "nvarchar(360)", maxLength: 360, nullable: false),
                Address_DeliveryAddress = table.Column<string>(type: "nvarchar(360)", maxLength: 360, nullable: false),
                PhoneNumber_Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Customer", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Customer");
    }
}
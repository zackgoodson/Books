using Microsoft.EntityFrameworkCore.Migrations;

namespace Books.Migrations
{
    public partial class AddPurchasesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "Purchases",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Purchases");
        }
    }
}

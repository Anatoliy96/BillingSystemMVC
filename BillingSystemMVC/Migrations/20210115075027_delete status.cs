using Microsoft.EntityFrameworkCore.Migrations;

namespace BillingSystemMVC.Migrations
{
    public partial class deletestatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Clients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Clients",
                type: "text",
                nullable: true);
        }
    }
}

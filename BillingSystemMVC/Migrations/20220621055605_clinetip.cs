using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillingSystemMVC.Migrations
{
    public partial class clinetip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "IPS",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "IPS");
        }
    }
}

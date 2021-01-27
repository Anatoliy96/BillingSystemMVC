using Microsoft.EntityFrameworkCore.Migrations;

namespace BillingSystemMVC.Migrations
{
    public partial class fixrepeatpasword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Profiles");

            migrationBuilder.AddColumn<string>(
                name: "RepeatPassword",
                table: "Profiles",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepeatPassword",
                table: "Profiles");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Profiles",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}

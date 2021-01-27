using Microsoft.EntityFrameworkCore.Migrations;

namespace BillingSystemMVC.Migrations
{
    public partial class DTpasswod1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Profiles",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Profiles",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Profiles");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Profiles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}

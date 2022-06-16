using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillingSystemMVC.Migrations
{
    public partial class newLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientLog_Clients_ClientId",
                table: "ClientLog");

            migrationBuilder.DropIndex(
                name: "IX_ClientLog_ClientId",
                table: "ClientLog");

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "ClientLog",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "ClientLog");

            migrationBuilder.CreateIndex(
                name: "IX_ClientLog_ClientId",
                table: "ClientLog",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientLog_Clients_ClientId",
                table: "ClientLog",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "IDNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

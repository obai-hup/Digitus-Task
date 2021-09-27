using Microsoft.EntityFrameworkCore.Migrations;

namespace Digitus_Task_.Migrations
{
    public partial class AddColmun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSend",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSend",
                table: "AspNetUsers");
        }
    }
}

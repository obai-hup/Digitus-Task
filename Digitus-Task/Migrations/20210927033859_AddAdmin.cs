using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Digitus_Task_.Migrations
{
    public partial class AddAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "AspNetUserRoles",
               columns: new[] { "UserId", "RoleId" },
               values: new object[] { "30afbb53-3f89-43d4-b423-19f4d5daab38", "25bb5356-9caf-45d4-9b1e-a0f3b5cbb843" }
               );

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "UserName", "Email", "Password" },
                values: new object[] { Guid.NewGuid().ToString(), "Admin", "Admin@Admin.com", "123456".ToUpper(), Guid.NewGuid().ToString() }
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetRoles]");
        }
    }
}

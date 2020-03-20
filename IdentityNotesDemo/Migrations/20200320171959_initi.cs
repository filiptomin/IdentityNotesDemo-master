using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityNotesDemo.Migrations
{
    public partial class initi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Notes",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ADMIN",
                column: "ConcurrencyStamp",
                value: "5f47bd06-1fb0-4ee2-a63d-1b3a54b69b6c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "USER",
                column: "ConcurrencyStamp",
                value: "4ab3c3cc-b5a9-4143-a866-5f2b01c6aae2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMINUSER",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "10a2cbe6-d814-4615-b89e-31e73c5a2dc1", "AQAAAAEAACcQAAAAEKYjmsGeT4ZndKK91j6HJs+ZDsTxqp0qRqNUM0t1MkRiuV6xrbCxu3WBnzVtW0n83g==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Notes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ADMIN",
                column: "ConcurrencyStamp",
                value: "cbd81c89-20a7-45c3-8b53-79abd3152021");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "USER",
                column: "ConcurrencyStamp",
                value: "ad5a68b0-d60b-49f9-b5b4-b79b068d01f9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMINUSER",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "757e3225-1554-457d-a413-8eabbaf49945", "AQAAAAEAACcQAAAAEDQFmn9fASrN4PTOEX0G8WbSFLkeuRKMAy8h+nL4cwSO+LxU5Aj7aeGeKPayz7X/JQ==" });
        }
    }
}

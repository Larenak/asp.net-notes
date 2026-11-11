using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeWebApp.Migrations
{
    /// <inheritdoc />
    public partial class LowercaseTableAndColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "notes");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "users",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "notes",
                newName: "text");

            migrationBuilder.RenameColumn(
                name: "Header",
                table: "notes",
                newName: "header");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "notes",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "notes",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_notes",
                table: "notes",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_notes",
                table: "notes");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "notes",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "text",
                table: "Notes",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "header",
                table: "Notes",
                newName: "Header");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Notes",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Notes",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "Id");
        }
    }
}

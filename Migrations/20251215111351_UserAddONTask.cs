using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Migrations
{
    /// <inheritdoc />
    public partial class UserAddONTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "TaskManage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "TaskManage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "TaskManage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByName",
                table: "TaskManage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "TaskManage");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "TaskManage");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "TaskManage");

            migrationBuilder.DropColumn(
                name: "UpdatedByName",
                table: "TaskManage");
        }
    }
}

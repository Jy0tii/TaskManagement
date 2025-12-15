using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialTaskManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskManage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaskDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    TaskDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskStatus = table.Column<bool>(type: "bit", nullable: false),
                    TaskRemarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskManage", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskManage");
        }
    }
}

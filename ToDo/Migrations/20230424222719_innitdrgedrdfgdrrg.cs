using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Migrations
{
    /// <inheritdoc />
    public partial class innitdrgedrdfgdrrg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TasksTimes_Tasks_TaskId",
                table: "TasksTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TasksTimes",
                table: "TasksTimes");

            migrationBuilder.RenameTable(
                name: "TasksTimes",
                newName: "TaskTimes");

            migrationBuilder.RenameIndex(
                name: "IX_TasksTimes_TaskId",
                table: "TaskTimes",
                newName: "IX_TaskTimes_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskTimes",
                table: "TaskTimes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskTimes_Tasks_TaskId",
                table: "TaskTimes",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskTimes_Tasks_TaskId",
                table: "TaskTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskTimes",
                table: "TaskTimes");

            migrationBuilder.RenameTable(
                name: "TaskTimes",
                newName: "TasksTimes");

            migrationBuilder.RenameIndex(
                name: "IX_TaskTimes_TaskId",
                table: "TasksTimes",
                newName: "IX_TasksTimes_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TasksTimes",
                table: "TasksTimes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TasksTimes_Tasks_TaskId",
                table: "TasksTimes",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

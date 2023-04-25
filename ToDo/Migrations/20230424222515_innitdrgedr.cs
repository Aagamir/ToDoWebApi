using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Migrations
{
    /// <inheritdoc />
    public partial class innitdrgedr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TasksTime_Tasks_TaskId",
                table: "TasksTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TasksTime",
                table: "TasksTime");

            migrationBuilder.RenameTable(
                name: "TasksTime",
                newName: "TasksTimes");

            migrationBuilder.RenameIndex(
                name: "IX_TasksTime_TaskId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TasksTimes_Tasks_TaskId",
                table: "TasksTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TasksTimes",
                table: "TasksTimes");

            migrationBuilder.RenameTable(
                name: "TasksTimes",
                newName: "TasksTime");

            migrationBuilder.RenameIndex(
                name: "IX_TasksTimes_TaskId",
                table: "TasksTime",
                newName: "IX_TasksTime_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TasksTime",
                table: "TasksTime",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TasksTime_Tasks_TaskId",
                table: "TasksTime",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

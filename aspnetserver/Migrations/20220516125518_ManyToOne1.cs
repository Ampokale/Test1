using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetserver.Migrations
{
    public partial class ManyToOne1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PIdNavigationPojectId",
                table: "task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaskStatusNavigationStatusId",
                table: "task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PIdNavigationPojectId",
                table: "reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "project",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_task_PIdNavigationPojectId",
                table: "task",
                column: "PIdNavigationPojectId");

            migrationBuilder.CreateIndex(
                name: "IX_task_TaskStatusNavigationStatusId",
                table: "task",
                column: "TaskStatusNavigationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_reports_PIdNavigationPojectId",
                table: "reports",
                column: "PIdNavigationPojectId");

            migrationBuilder.CreateIndex(
                name: "IX_projectMember_projectId",
                table: "projectMember",
                column: "projectId");

            migrationBuilder.CreateIndex(
                name: "IX_projectMember_UserID",
                table: "projectMember",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_project_UserId",
                table: "project",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_project_user_UserId",
                table: "project",
                column: "UserId",
                principalTable: "user",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_projectMember_project_projectId",
                table: "projectMember",
                column: "projectId",
                principalTable: "project",
                principalColumn: "PojectId");

            migrationBuilder.AddForeignKey(
                name: "FK_projectMember_user_UserID",
                table: "projectMember",
                column: "UserID",
                principalTable: "user",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_reports_project_PIdNavigationPojectId",
                table: "reports",
                column: "PIdNavigationPojectId",
                principalTable: "project",
                principalColumn: "PojectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_task_project_PIdNavigationPojectId",
                table: "task",
                column: "PIdNavigationPojectId",
                principalTable: "project",
                principalColumn: "PojectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_task_status_TaskStatusNavigationStatusId",
                table: "task",
                column: "TaskStatusNavigationStatusId",
                principalTable: "status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_project_user_UserId",
                table: "project");

            migrationBuilder.DropForeignKey(
                name: "FK_projectMember_project_projectId",
                table: "projectMember");

            migrationBuilder.DropForeignKey(
                name: "FK_projectMember_user_UserID",
                table: "projectMember");

            migrationBuilder.DropForeignKey(
                name: "FK_reports_project_PIdNavigationPojectId",
                table: "reports");

            migrationBuilder.DropForeignKey(
                name: "FK_task_project_PIdNavigationPojectId",
                table: "task");

            migrationBuilder.DropForeignKey(
                name: "FK_task_status_TaskStatusNavigationStatusId",
                table: "task");

            migrationBuilder.DropIndex(
                name: "IX_task_PIdNavigationPojectId",
                table: "task");

            migrationBuilder.DropIndex(
                name: "IX_task_TaskStatusNavigationStatusId",
                table: "task");

            migrationBuilder.DropIndex(
                name: "IX_reports_PIdNavigationPojectId",
                table: "reports");

            migrationBuilder.DropIndex(
                name: "IX_projectMember_projectId",
                table: "projectMember");

            migrationBuilder.DropIndex(
                name: "IX_projectMember_UserID",
                table: "projectMember");

            migrationBuilder.DropIndex(
                name: "IX_project_UserId",
                table: "project");

            migrationBuilder.DropColumn(
                name: "PIdNavigationPojectId",
                table: "task");

            migrationBuilder.DropColumn(
                name: "TaskStatusNavigationStatusId",
                table: "task");

            migrationBuilder.DropColumn(
                name: "PIdNavigationPojectId",
                table: "reports");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "project");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetserver.Migrations.NetFSD
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "statusTable",
                columns: table => new
                {
                    statusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sDetail = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__statusTa__36257A18B33680BD", x => x.statusId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    Roles = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true, defaultValueSql: "('Member')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.UniqueConstraint("AK_Users_Email", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    projectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    projectDesc = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    createdBy = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    startdate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.projectId);
                    table.ForeignKey(
                        name: "FK__Projects__create__45BE5BA9",
                        column: x => x.createdBy,
                        principalTable: "Users",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateTable(
                name: "projectMembers",
                columns: table => new
                {
                    projMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectId = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectMembers", x => x.projMemberId);
                    table.ForeignKey(
                        name: "FK__projectMe__email__4F47C5E3",
                        column: x => x.email,
                        principalTable: "Users",
                        principalColumn: "Email");
                    table.ForeignKey(
                        name: "FK__projectMe__proje__4D5F7D71",
                        column: x => x.projectId,
                        principalTable: "Projects",
                        principalColumn: "projectId");
                    table.ForeignKey(
                        name: "FK__projectMe__UserI__4E53A1AA",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "reportTb",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pId = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    taskstatus = table.Column<int>(type: "int", nullable: false),
                    taskDetails = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    whatAction = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    reportedOn = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_Report__DC11576792592C7A", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK__report__pId__634EBE90",
                        column: x => x.pId,
                        principalTable: "Projects",
                        principalColumn: "projectId");
                });

            migrationBuilder.CreateTable(
                name: "tb_Task",
                columns: table => new
                {
                    tId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pId = table.Column<int>(type: "int", nullable: true),
                    AssignedTo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    taskDetails = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    taskStatus = table.Column<int>(type: "int", nullable: true),
                    assignedBy = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tb_Task__DC11576792592C7A", x => x.tId);
                    table.ForeignKey(
                        name: "FK__tb_Task__pId__531856C7",
                        column: x => x.pId,
                        principalTable: "Projects",
                        principalColumn: "projectId");
                    table.ForeignKey(
                        name: "FK__tb_Task__taskSta__540C7B00",
                        column: x => x.taskStatus,
                        principalTable: "statusTable",
                        principalColumn: "statusId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_projectMembers_email",
                table: "projectMembers",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "IX_projectMembers_projectId",
                table: "projectMembers",
                column: "projectId");

            migrationBuilder.CreateIndex(
                name: "IX_projectMembers_UserID",
                table: "projectMembers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_createdBy",
                table: "Projects",
                column: "createdBy");

            migrationBuilder.CreateIndex(
                name: "IX_reportTb_pId",
                table: "reportTb",
                column: "pId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Task_pId",
                table: "tb_Task",
                column: "pId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Task_taskStatus",
                table: "tb_Task",
                column: "taskStatus");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D10534A77A9C9F",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "projectMembers");

            migrationBuilder.DropTable(
                name: "reportTb");

            migrationBuilder.DropTable(
                name: "tb_Task");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "statusTable");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

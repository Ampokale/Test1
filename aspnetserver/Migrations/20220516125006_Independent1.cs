using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetserver.Migrations
{
    public partial class Independent1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    RId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Taskstatus = table.Column<int>(type: "int", nullable: false),
                    TaskDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatAction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reports", x => x.RId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reports");
        }
    }
}

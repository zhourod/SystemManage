using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZhouRod.SystemManage.Migrations
{
    public partial class addtask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TMPerson",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMPerson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TMTask",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedPersonId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    State = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TMTask_TMPerson_AssignedPersonId",
                        column: x => x.AssignedPersonId,
                        principalTable: "TMPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TMTask_AssignedPersonId",
                table: "TMTask",
                column: "AssignedPersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TMTask");

            migrationBuilder.DropTable(
                name: "TMPerson");
        }
    }
}

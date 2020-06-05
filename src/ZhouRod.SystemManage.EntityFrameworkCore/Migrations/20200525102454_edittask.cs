using Microsoft.EntityFrameworkCore.Migrations;

namespace ZhouRod.SystemManage.Migrations
{
    public partial class edittask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TMTask_TMPerson_AssignedPersonId",
                table: "TMTask");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TMTask",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssignedPersonId",
                table: "TMTask",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TMTask_TMPerson_AssignedPersonId",
                table: "TMTask",
                column: "AssignedPersonId",
                principalTable: "TMPerson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TMTask_TMPerson_AssignedPersonId",
                table: "TMTask");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TMTask",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "AssignedPersonId",
                table: "TMTask",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TMTask_TMPerson_AssignedPersonId",
                table: "TMTask",
                column: "AssignedPersonId",
                principalTable: "TMPerson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

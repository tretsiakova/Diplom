using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppMobileRecord.Data.Migrations
{
    public partial class id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignMobileIdentities_AspNetUsers_IdentityId1",
                table: "AssignMobileIdentities");

            migrationBuilder.DropIndex(
                name: "IX_AssignMobileIdentities_IdentityId1",
                table: "AssignMobileIdentities");

            migrationBuilder.DropColumn(
                name: "IdentityId1",
                table: "AssignMobileIdentities");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityId",
                table: "AssignMobileIdentities",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_AssignMobileIdentities_IdentityId",
                table: "AssignMobileIdentities",
                column: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignMobileIdentities_AspNetUsers_IdentityId",
                table: "AssignMobileIdentities",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignMobileIdentities_AspNetUsers_IdentityId",
                table: "AssignMobileIdentities");

            migrationBuilder.DropIndex(
                name: "IX_AssignMobileIdentities_IdentityId",
                table: "AssignMobileIdentities");

            migrationBuilder.AlterColumn<int>(
                name: "IdentityId",
                table: "AssignMobileIdentities",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityId1",
                table: "AssignMobileIdentities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignMobileIdentities_IdentityId1",
                table: "AssignMobileIdentities",
                column: "IdentityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignMobileIdentities_AspNetUsers_IdentityId1",
                table: "AssignMobileIdentities",
                column: "IdentityId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

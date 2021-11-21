using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppMobileRecord.Data.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MobileStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MobileTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OSTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OSTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OSTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OSVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<string>(nullable: true),
                    OSTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OSVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OSVersions_OSTypes_OSTypeId",
                        column: x => x.OSTypeId,
                        principalTable: "OSTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mobiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    DeactivatedDate = table.Column<DateTime>(nullable: false),
                    OSVersionId = table.Column<int>(nullable: false),
                    MobileStatusId = table.Column<int>(nullable: false),
                    MobileTypeId = table.Column<int>(nullable: false),
                    VendorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mobiles_MobileStatuses_MobileStatusId",
                        column: x => x.MobileStatusId,
                        principalTable: "MobileStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mobiles_MobileTypes_MobileTypeId",
                        column: x => x.MobileTypeId,
                        principalTable: "MobileTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mobiles_OSVersions_OSVersionId",
                        column: x => x.OSVersionId,
                        principalTable: "OSVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mobiles_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignMobileIdentities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignDate = table.Column<DateTime>(nullable: false),
                    UnAssignDate = table.Column<DateTime>(nullable: false),
                    IdentityId = table.Column<int>(nullable: false),
                    IdentityId1 = table.Column<string>(nullable: true),
                    MobileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignMobileIdentities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignMobileIdentities_AspNetUsers_IdentityId1",
                        column: x => x.IdentityId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssignMobileIdentities_Mobiles_MobileId",
                        column: x => x.MobileId,
                        principalTable: "Mobiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignMobileIdentities_IdentityId1",
                table: "AssignMobileIdentities",
                column: "IdentityId1");

            migrationBuilder.CreateIndex(
                name: "IX_AssignMobileIdentities_MobileId",
                table: "AssignMobileIdentities",
                column: "MobileId");

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_MobileStatusId",
                table: "Mobiles",
                column: "MobileStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_MobileTypeId",
                table: "Mobiles",
                column: "MobileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_OSVersionId",
                table: "Mobiles",
                column: "OSVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_VendorId",
                table: "Mobiles",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_OSVersions_OSTypeId",
                table: "OSVersions",
                column: "OSTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignMobileIdentities");

            migrationBuilder.DropTable(
                name: "Mobiles");

            migrationBuilder.DropTable(
                name: "MobileStatuses");

            migrationBuilder.DropTable(
                name: "MobileTypes");

            migrationBuilder.DropTable(
                name: "OSVersions");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "OSTypes");
        }
    }
}

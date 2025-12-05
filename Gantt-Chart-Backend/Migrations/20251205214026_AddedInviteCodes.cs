using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gantt_Chart_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddedInviteCodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InviteCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InviteCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InviteCodes_project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InviteCodes_Code",
                table: "InviteCodes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InviteCodes_ProjectId",
                table: "InviteCodes",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InviteCodes");
        }
    }
}

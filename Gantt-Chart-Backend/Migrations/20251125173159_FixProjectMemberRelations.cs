using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gantt_Chart_Backend.Migrations
{
    /// <inheritdoc />
    public partial class FixProjectMemberRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_project_member_project_ProjectId1",
                table: "project_member");

            migrationBuilder.DropIndex(
                name: "IX_project_member_ProjectId1",
                table: "project_member");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "project_member");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId1",
                table: "project_member",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_project_member_ProjectId1",
                table: "project_member",
                column: "ProjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_project_member_project_ProjectId1",
                table: "project_member",
                column: "ProjectId1",
                principalTable: "project",
                principalColumn: "Id");
        }
    }
}

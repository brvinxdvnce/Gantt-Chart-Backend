using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gantt_Chart_Backend.Migrations
{
    /// <inheritdoc />
    public partial class FixPKPM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionProjectMember_project_member_ProjectMemberId",
                table: "PermissionProjectMember");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMemberTeam_project_member_PerformersId",
                table: "ProjectMemberTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_team_project_member_LeaderId",
                table: "team");

            migrationBuilder.DropIndex(
                name: "IX_team_LeaderId",
                table: "team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_project_member",
                table: "project_member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectMemberTeam",
                table: "ProjectMemberTeam");

            migrationBuilder.DropIndex(
                name: "IX_ProjectMemberTeam_TeamId",
                table: "ProjectMemberTeam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionProjectMember",
                table: "PermissionProjectMember");

            migrationBuilder.DropIndex(
                name: "IX_PermissionProjectMember_ProjectMemberId",
                table: "PermissionProjectMember");

            migrationBuilder.AddColumn<Guid>(
                name: "PerformersProjectId",
                table: "ProjectMemberTeam",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectMemberProjectId",
                table: "PermissionProjectMember",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_project_member",
                table: "project_member",
                columns: new[] { "Id", "ProjectId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectMemberTeam",
                table: "ProjectMemberTeam",
                columns: new[] { "TeamId", "PerformersId", "PerformersProjectId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionProjectMember",
                table: "PermissionProjectMember",
                columns: new[] { "PermissionsId", "ProjectMemberId", "ProjectMemberProjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_team_LeaderId_ProjectId",
                table: "team",
                columns: new[] { "LeaderId", "ProjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMemberTeam_PerformersId_PerformersProjectId",
                table: "ProjectMemberTeam",
                columns: new[] { "PerformersId", "PerformersProjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionProjectMember_ProjectMemberId_ProjectMemberProjec~",
                table: "PermissionProjectMember",
                columns: new[] { "ProjectMemberId", "ProjectMemberProjectId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionProjectMember_project_member_ProjectMemberId_Proj~",
                table: "PermissionProjectMember",
                columns: new[] { "ProjectMemberId", "ProjectMemberProjectId" },
                principalTable: "project_member",
                principalColumns: new[] { "Id", "ProjectId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMemberTeam_project_member_PerformersId_PerformersPro~",
                table: "ProjectMemberTeam",
                columns: new[] { "PerformersId", "PerformersProjectId" },
                principalTable: "project_member",
                principalColumns: new[] { "Id", "ProjectId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_team_project_member_LeaderId_ProjectId",
                table: "team",
                columns: new[] { "LeaderId", "ProjectId" },
                principalTable: "project_member",
                principalColumns: new[] { "Id", "ProjectId" },
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionProjectMember_project_member_ProjectMemberId_Proj~",
                table: "PermissionProjectMember");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMemberTeam_project_member_PerformersId_PerformersPro~",
                table: "ProjectMemberTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_team_project_member_LeaderId_ProjectId",
                table: "team");

            migrationBuilder.DropIndex(
                name: "IX_team_LeaderId_ProjectId",
                table: "team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_project_member",
                table: "project_member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectMemberTeam",
                table: "ProjectMemberTeam");

            migrationBuilder.DropIndex(
                name: "IX_ProjectMemberTeam_PerformersId_PerformersProjectId",
                table: "ProjectMemberTeam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionProjectMember",
                table: "PermissionProjectMember");

            migrationBuilder.DropIndex(
                name: "IX_PermissionProjectMember_ProjectMemberId_ProjectMemberProjec~",
                table: "PermissionProjectMember");

            migrationBuilder.DropColumn(
                name: "PerformersProjectId",
                table: "ProjectMemberTeam");

            migrationBuilder.DropColumn(
                name: "ProjectMemberProjectId",
                table: "PermissionProjectMember");

            migrationBuilder.AddPrimaryKey(
                name: "PK_project_member",
                table: "project_member",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectMemberTeam",
                table: "ProjectMemberTeam",
                columns: new[] { "PerformersId", "TeamId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionProjectMember",
                table: "PermissionProjectMember",
                columns: new[] { "PermissionsId", "ProjectMemberId" });

            migrationBuilder.CreateIndex(
                name: "IX_team_LeaderId",
                table: "team",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMemberTeam_TeamId",
                table: "ProjectMemberTeam",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionProjectMember_ProjectMemberId",
                table: "PermissionProjectMember",
                column: "ProjectMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionProjectMember_project_member_ProjectMemberId",
                table: "PermissionProjectMember",
                column: "ProjectMemberId",
                principalTable: "project_member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMemberTeam_project_member_PerformersId",
                table: "ProjectMemberTeam",
                column: "PerformersId",
                principalTable: "project_member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_team_project_member_LeaderId",
                table: "team",
                column: "LeaderId",
                principalTable: "project_member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

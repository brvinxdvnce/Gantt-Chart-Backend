using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gantt_Chart_Backend.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "permission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NickName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaskId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_user_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionProjectMember",
                columns: table => new
                {
                    PermissionsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectMemberId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionProjectMember", x => new { x.PermissionsId, x.ProjectMemberId });
                    table.ForeignKey(
                        name: "FK_PermissionProjectMember_permission_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectMemberTeam",
                columns: table => new
                {
                    PerformersId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeamId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMemberTeam", x => new { x.PerformersId, x.TeamId });
                });

            migrationBuilder.CreateTable(
                name: "dependence",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    ChildId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dependence", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    RootTaskId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeadLine = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_project_user_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "task",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_task_project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "project_member",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    ProjectId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    ProjectTaskId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_project_member_project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_project_member_project_ProjectId1",
                        column: x => x.ProjectId1,
                        principalTable: "project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_project_member_task_ProjectTaskId",
                        column: x => x.ProjectTaskId,
                        principalTable: "task",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_project_member_user_Id",
                        column: x => x.Id,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "team",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LeaderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectTaskId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_team_project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_team_project_member_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "project_member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_team_task_ProjectTaskId",
                        column: x => x.ProjectTaskId,
                        principalTable: "task",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TaskId",
                table: "Comments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionProjectMember_ProjectMemberId",
                table: "PermissionProjectMember",
                column: "ProjectMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMemberTeam_TeamId",
                table: "ProjectMemberTeam",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_dependence_ChildId",
                table: "dependence",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_dependence_ParentId",
                table: "dependence",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_project_CreatorId",
                table: "project",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_project_RootTaskId",
                table: "project",
                column: "RootTaskId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_project_member_ProjectId",
                table: "project_member",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_project_member_ProjectId1",
                table: "project_member",
                column: "ProjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_project_member_ProjectTaskId",
                table: "project_member",
                column: "ProjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_task_ProjectId",
                table: "task",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_team_LeaderId",
                table: "team",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_team_ProjectId",
                table: "team",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_team_ProjectTaskId",
                table: "team",
                column: "ProjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_user_Email",
                table: "user",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_task_TaskId",
                table: "Comments",
                column: "TaskId",
                principalTable: "task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_ProjectMemberTeam_team_TeamId",
                table: "ProjectMemberTeam",
                column: "TeamId",
                principalTable: "team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dependence_task_ChildId",
                table: "dependence",
                column: "ChildId",
                principalTable: "task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dependence_task_ParentId",
                table: "dependence",
                column: "ParentId",
                principalTable: "task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_project_task_RootTaskId",
                table: "project",
                column: "RootTaskId",
                principalTable: "task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_project_task_RootTaskId",
                table: "project");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PermissionProjectMember");

            migrationBuilder.DropTable(
                name: "ProjectMemberTeam");

            migrationBuilder.DropTable(
                name: "dependence");

            migrationBuilder.DropTable(
                name: "permission");

            migrationBuilder.DropTable(
                name: "team");

            migrationBuilder.DropTable(
                name: "project_member");

            migrationBuilder.DropTable(
                name: "task");

            migrationBuilder.DropTable(
                name: "project");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumProject.Persistence.Migrations
{
    public partial class addbacklogcomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BackLogComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BackLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(1024)", nullable: false),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackLogComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BackLogComments_BackLogs_BackLogId",
                        column: x => x.BackLogId,
                        principalTable: "BackLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BackLogComments_BackLogId",
                table: "BackLogComments",
                column: "BackLogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackLogComments");
        }
    }
}

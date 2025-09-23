using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteWiki.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoteBoxes",
                columns: table => new
                {
                    NoteBoxGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoxName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteBoxes", x => x.NoteBoxGuid);
                });

            migrationBuilder.CreateTable(
                name: "NoteMetadata",
                columns: table => new
                {
                    NoteGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoteBoxGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteMetadata", x => x.NoteGuid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteBoxes");

            migrationBuilder.DropTable(
                name: "NoteMetadata");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

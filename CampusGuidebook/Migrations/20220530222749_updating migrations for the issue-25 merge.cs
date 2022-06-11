using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusGuidebook.Migrations
{
    public partial class updatingmigrationsfortheissue25merge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventConditions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    condition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventConditions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EventTable",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eventTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTable", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventConditions");

            migrationBuilder.DropTable(
                name: "EventTable");
        }
    }
}

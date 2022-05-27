using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusGuidebook.Migrations
{
    public partial class addingineventdatetodatamodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "eventDate",
                table: "EventTable",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "eventDate",
                table: "EventTable");
        }
    }
}

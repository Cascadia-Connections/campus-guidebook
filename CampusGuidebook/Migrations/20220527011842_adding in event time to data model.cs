using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusGuidebook.Migrations
{
    public partial class addingineventtimetodatamodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "eventTime",
                table: "EventTable",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "eventTime",
                table: "EventTable");
        }
    }
}

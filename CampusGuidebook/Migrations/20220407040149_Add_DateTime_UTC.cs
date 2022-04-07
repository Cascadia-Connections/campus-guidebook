using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusGuidebook.Migrations
{
    public partial class Add_DateTime_UTC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "lastUpdated",
                table: "_Db",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lastUpdated",
                table: "_Db");
        }
    }
}

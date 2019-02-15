using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace todoProject.Data.Migrations
{
    public partial class AddDateFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Todos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 13, 17, 1, 18, 912, DateTimeKind.Local));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateExpired",
                table: "Todos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Todos",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "DateExpired",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Todos");
        }
    }
}

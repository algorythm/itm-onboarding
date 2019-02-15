using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace todoProject.Data.Migrations
{
    public partial class AddPriorityToTodos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Todos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 14, 15, 48, 56, 532, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 13, 17, 1, 18, 912, DateTimeKind.Local));

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Todos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Todos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Todos",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 13, 17, 1, 18, 912, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 2, 14, 15, 48, 56, 532, DateTimeKind.Local));
        }
    }
}

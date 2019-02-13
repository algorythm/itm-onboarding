using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace todoProject.Data.Migrations
{
    public partial class AssociateTodoWithUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Todos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_OwnerId",
                table: "Todos",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_AspNetUsers_OwnerId",
                table: "Todos",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_AspNetUsers_OwnerId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_OwnerId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Todos");
        }
    }
}

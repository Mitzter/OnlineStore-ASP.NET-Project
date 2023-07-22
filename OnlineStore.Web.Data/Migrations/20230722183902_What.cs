﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Web.Data.Migrations
{
    public partial class What : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_AspNetUsers_PosterId1",
                table: "ForumPosts");

            migrationBuilder.DropIndex(
                name: "IX_ForumPosts_PosterId1",
                table: "ForumPosts");

            migrationBuilder.DropColumn(
                name: "PosterId1",
                table: "ForumPosts");

            migrationBuilder.AlterColumn<string>(
                name: "PosterId",
                table: "ForumPosts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPosts_PosterId",
                table: "ForumPosts",
                column: "PosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_AspNetUsers_PosterId",
                table: "ForumPosts",
                column: "PosterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_AspNetUsers_PosterId",
                table: "ForumPosts");

            migrationBuilder.DropIndex(
                name: "IX_ForumPosts_PosterId",
                table: "ForumPosts");

            migrationBuilder.AlterColumn<int>(
                name: "PosterId",
                table: "ForumPosts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosterId1",
                table: "ForumPosts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ForumPosts_PosterId1",
                table: "ForumPosts",
                column: "PosterId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_AspNetUsers_PosterId1",
                table: "ForumPosts",
                column: "PosterId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Web.Data.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_PosterId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_ForumCategory_CategoryId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Reply_AspNetUsers_UserId",
                table: "Reply");

            migrationBuilder.DropForeignKey(
                name: "FK_Reply_Post_PostedAtId",
                table: "Reply");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reply",
                table: "Reply");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForumCategory",
                table: "ForumCategory");

            migrationBuilder.RenameTable(
                name: "Reply",
                newName: "ForumReplies");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "ForumPosts");

            migrationBuilder.RenameTable(
                name: "ForumCategory",
                newName: "ForumCategories");

            migrationBuilder.RenameIndex(
                name: "IX_Reply_UserId",
                table: "ForumReplies",
                newName: "IX_ForumReplies_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reply_PostedAtId",
                table: "ForumReplies",
                newName: "IX_ForumReplies_PostedAtId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_PosterId",
                table: "ForumPosts",
                newName: "IX_ForumPosts_PosterId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_CategoryId",
                table: "ForumPosts",
                newName: "IX_ForumPosts_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForumReplies",
                table: "ForumReplies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForumPosts",
                table: "ForumPosts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForumCategories",
                table: "ForumCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_AspNetUsers_PosterId",
                table: "ForumPosts",
                column: "PosterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_ForumCategories_CategoryId",
                table: "ForumPosts",
                column: "CategoryId",
                principalTable: "ForumCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumReplies_AspNetUsers_UserId",
                table: "ForumReplies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumReplies_ForumPosts_PostedAtId",
                table: "ForumReplies",
                column: "PostedAtId",
                principalTable: "ForumPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_AspNetUsers_PosterId",
                table: "ForumPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_ForumCategories_CategoryId",
                table: "ForumPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumReplies_AspNetUsers_UserId",
                table: "ForumReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumReplies_ForumPosts_PostedAtId",
                table: "ForumReplies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForumReplies",
                table: "ForumReplies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForumPosts",
                table: "ForumPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForumCategories",
                table: "ForumCategories");

            migrationBuilder.RenameTable(
                name: "ForumReplies",
                newName: "Reply");

            migrationBuilder.RenameTable(
                name: "ForumPosts",
                newName: "Post");

            migrationBuilder.RenameTable(
                name: "ForumCategories",
                newName: "ForumCategory");

            migrationBuilder.RenameIndex(
                name: "IX_ForumReplies_UserId",
                table: "Reply",
                newName: "IX_Reply_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ForumReplies_PostedAtId",
                table: "Reply",
                newName: "IX_Reply_PostedAtId");

            migrationBuilder.RenameIndex(
                name: "IX_ForumPosts_PosterId",
                table: "Post",
                newName: "IX_Post_PosterId");

            migrationBuilder.RenameIndex(
                name: "IX_ForumPosts_CategoryId",
                table: "Post",
                newName: "IX_Post_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reply",
                table: "Reply",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForumCategory",
                table: "ForumCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_PosterId",
                table: "Post",
                column: "PosterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_ForumCategory_CategoryId",
                table: "Post",
                column: "CategoryId",
                principalTable: "ForumCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reply_AspNetUsers_UserId",
                table: "Reply",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reply_Post_PostedAtId",
                table: "Reply",
                column: "PostedAtId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

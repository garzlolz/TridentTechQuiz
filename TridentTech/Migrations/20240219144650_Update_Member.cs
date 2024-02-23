using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TridentTech.Migrations
{
    /// <inheritdoc />
    public partial class Update_Member : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "member_id",
                table: "classes",
                type: "int",
                nullable: true,
                comment: "會員 Id");

            migrationBuilder.CreateIndex(
                name: "IX_classes_member_id",
                table: "classes",
                column: "member_id");

            migrationBuilder.AddForeignKey(
                name: "FK_classes_members_member_id",
                table: "classes",
                column: "member_id",
                principalTable: "members",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classes_members_member_id",
                table: "classes");

            migrationBuilder.DropIndex(
                name: "IX_classes_member_id",
                table: "classes");

            migrationBuilder.DropColumn(
                name: "member_id",
                table: "classes");
        }
    }
}

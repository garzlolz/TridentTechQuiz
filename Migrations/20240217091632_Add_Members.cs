using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TridentTech.Migrations
{
    /// <inheritdoc />
    public partial class Add_Members : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    member_account = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "帳號"),
                    member_password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "密碼"),
                    is_teacher = table.Column<bool>(type: "bit", maxLength: 100, nullable: false, comment: "是否為老師")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "members");
        }
    }
}

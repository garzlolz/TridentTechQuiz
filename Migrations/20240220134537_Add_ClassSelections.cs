using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TridentTech.Migrations
{
    /// <inheritdoc />
    public partial class Add_ClassSelections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "class_selections",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "member_id"),
                    class_id = table.Column<int>(type: "int", nullable: false, comment: "所屬課程Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class_selections", x => x.id);
                    table.ForeignKey(
                        name: "FK_class_selections_classes_class_id",
                        column: x => x.class_id,
                        principalTable: "classes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_class_selections_members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "members",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_class_selections_class_id",
                table: "class_selections",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_class_selections_MemberId",
                table: "class_selections",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "class_selections");
        }
    }
}

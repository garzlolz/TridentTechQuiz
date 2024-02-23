using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TridentTech.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    class_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "課程名稱"),
                    class_description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "課程描述")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacher_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "老師姓名"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "E-mail")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.id);
                },
                comment: "老師Table");

            migrationBuilder.CreateTable(
                name: "teacher_classes",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    StartAt = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_classes", x => new { x.TeacherId, x.ClassId, x.StartAt });
                    table.ForeignKey(
                        name: "FK_teacher_classes_classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "classes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_classes_teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "老師Table");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_classes_ClassId",
                table: "teacher_classes",
                column: "ClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "teacher_classes");

            migrationBuilder.DropTable(
                name: "classes");

            migrationBuilder.DropTable(
                name: "teachers");
        }
    }
}

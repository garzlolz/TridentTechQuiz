using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TridentTech.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Teacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "teacher_classes");

            migrationBuilder.DropTable(
                name: "teachers");

            migrationBuilder.AlterColumn<string>(
                name: "class_description",
                table: "classes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "課程描述",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "課程描述");

            migrationBuilder.AddColumn<string>(
                name: "end_at",
                table: "classes",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "",
                comment: "下課時間");

            migrationBuilder.AddColumn<string>(
                name: "start_at",
                table: "classes",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "",
                comment: "上課時間");

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    member_account = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "帳號"),
                    member_password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "密碼"),
                    member_name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "姓名"),
                    member_email = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "E-mail"),
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

            migrationBuilder.DropColumn(
                name: "end_at",
                table: "classes");

            migrationBuilder.DropColumn(
                name: "start_at",
                table: "classes");

            migrationBuilder.AlterColumn<string>(
                name: "class_description",
                table: "classes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "課程描述",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldComment: "課程描述");

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
    }
}

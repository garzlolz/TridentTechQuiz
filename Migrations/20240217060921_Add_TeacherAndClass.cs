using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TridentTech.Migrations
{
    /// <inheritdoc />
    public partial class Add_TeacherAndClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "teacher_classes");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "teachers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "E-mail",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "E-mail");

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

            migrationBuilder.AddColumn<int>(
                name: "teacher_id",
                table: "classes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_classes_teacher_id",
                table: "classes",
                column: "teacher_id");

            migrationBuilder.AddForeignKey(
                name: "FK_classes_teachers_teacher_id",
                table: "classes",
                column: "teacher_id",
                principalTable: "teachers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classes_teachers_teacher_id",
                table: "classes");

            migrationBuilder.DropIndex(
                name: "IX_classes_teacher_id",
                table: "classes");

            migrationBuilder.DropColumn(
                name: "end_at",
                table: "classes");

            migrationBuilder.DropColumn(
                name: "start_at",
                table: "classes");

            migrationBuilder.DropColumn(
                name: "teacher_id",
                table: "classes");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "teachers",
                type: "nvarchar(max)",
                nullable: false,
                comment: "E-mail",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "E-mail");

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

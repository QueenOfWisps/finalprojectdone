using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "QuizResults",
                columns: table => new
                {
                    QuizID = table.Column<string>(nullable: false),
                    Q_userUserID = table.Column<int>(nullable: true),
                    Score = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizResults", x => x.QuizID);
                    table.ForeignKey(
                        name: "FK_QuizResults_Users_Q_userUserID",
                        column: x => x.Q_userUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_userUserID = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    F_scoreQuizID = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_Posts_QuizResults_F_scoreQuizID",
                        column: x => x.F_scoreQuizID,
                        principalTable: "QuizResults",
                        principalColumn: "QuizID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Users_F_userUserID",
                        column: x => x.F_userUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_F_scoreQuizID",
                table: "Posts",
                column: "F_scoreQuizID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_F_userUserID",
                table: "Posts",
                column: "F_userUserID");

            migrationBuilder.CreateIndex(
                name: "IX_QuizResults_Q_userUserID",
                table: "QuizResults",
                column: "Q_userUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "QuizResults");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

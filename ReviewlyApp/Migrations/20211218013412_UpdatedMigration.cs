using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewlyApp.Migrations
{
    public partial class UpdatedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Films_FilmsFilmId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_FilmsFilmId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "FilmsFilmId",
                table: "Genres");

            migrationBuilder.AlterColumn<string>(
                name: "FilmTitle",
                table: "Films",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FilmsGenre",
                columns: table => new
                {
                    FilmsFilmId = table.Column<int>(type: "int", nullable: false),
                    GenresGenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmsGenre", x => new { x.FilmsFilmId, x.GenresGenreId });
                    table.ForeignKey(
                        name: "FK_FilmsGenre_Films_FilmsFilmId",
                        column: x => x.FilmsFilmId,
                        principalTable: "Films",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmsGenre_Genres_GenresGenreId",
                        column: x => x.GenresGenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmsGenre_GenresGenreId",
                table: "FilmsGenre",
                column: "GenresGenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmsGenre");

            migrationBuilder.AddColumn<int>(
                name: "FilmsFilmId",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FilmTitle",
                table: "Films",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_FilmsFilmId",
                table: "Genres",
                column: "FilmsFilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Films_FilmsFilmId",
                table: "Genres",
                column: "FilmsFilmId",
                principalTable: "Films",
                principalColumn: "FilmId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dometrain.EFCore.API.Migrations
{
    /// <inheritdoc />
    public partial class AddAlternateKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Genres_MainGenreId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_MainGenreId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "MainGenreId",
                table: "Pictures");

            migrationBuilder.AddColumn<string>(
                name: "MainGenreName",
                table: "Pictures",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Genres_Name",
                table: "Genres",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_MainGenreName",
                table: "Pictures",
                column: "MainGenreName");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Genres_MainGenreName",
                table: "Pictures",
                column: "MainGenreName",
                principalTable: "Genres",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Genres_MainGenreName",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_MainGenreName",
                table: "Pictures");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Genres_Name",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "MainGenreName",
                table: "Pictures");

            migrationBuilder.AddColumn<int>(
                name: "MainGenreId",
                table: "Pictures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_MainGenreId",
                table: "Pictures",
                column: "MainGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Genres_MainGenreId",
                table: "Pictures",
                column: "MainGenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

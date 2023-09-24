using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dometrain.EFCore.API.Migrations
{
    /// <inheritdoc />
    public partial class TablePerConcreteClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaMovie_Pictures_Identifier",
                table: "CinemaMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_TelevisionMovie_Pictures_Identifier",
                table: "TelevisionMovie");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.CreateSequence(
                name: "MovieSequence");

            migrationBuilder.AlterColumn<int>(
                name: "Identifier",
                table: "TelevisionMovie",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR [MovieSequence]",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AgeRating",
                table: "TelevisionMovie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "InternetRating",
                table: "TelevisionMovie",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MainGenreId",
                table: "TelevisionMovie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Plot",
                table: "TelevisionMovie",
                type: "varchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "TelevisionMovie",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "TelevisionMovie",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Identifier",
                table: "CinemaMovie",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR [MovieSequence]",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AgeRating",
                table: "CinemaMovie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "InternetRating",
                table: "CinemaMovie",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MainGenreId",
                table: "CinemaMovie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Plot",
                table: "CinemaMovie",
                type: "varchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "CinemaMovie",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CinemaMovie",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TelevisionMovie_MainGenreId",
                table: "TelevisionMovie",
                column: "MainGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaMovie_MainGenreId",
                table: "CinemaMovie",
                column: "MainGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaMovie_Genres_MainGenreId",
                table: "CinemaMovie",
                column: "MainGenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TelevisionMovie_Genres_MainGenreId",
                table: "TelevisionMovie",
                column: "MainGenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaMovie_Genres_MainGenreId",
                table: "CinemaMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_TelevisionMovie_Genres_MainGenreId",
                table: "TelevisionMovie");

            migrationBuilder.DropIndex(
                name: "IX_TelevisionMovie_MainGenreId",
                table: "TelevisionMovie");

            migrationBuilder.DropIndex(
                name: "IX_CinemaMovie_MainGenreId",
                table: "CinemaMovie");

            migrationBuilder.DropColumn(
                name: "AgeRating",
                table: "TelevisionMovie");

            migrationBuilder.DropColumn(
                name: "InternetRating",
                table: "TelevisionMovie");

            migrationBuilder.DropColumn(
                name: "MainGenreId",
                table: "TelevisionMovie");

            migrationBuilder.DropColumn(
                name: "Plot",
                table: "TelevisionMovie");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "TelevisionMovie");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "TelevisionMovie");

            migrationBuilder.DropColumn(
                name: "AgeRating",
                table: "CinemaMovie");

            migrationBuilder.DropColumn(
                name: "InternetRating",
                table: "CinemaMovie");

            migrationBuilder.DropColumn(
                name: "MainGenreId",
                table: "CinemaMovie");

            migrationBuilder.DropColumn(
                name: "Plot",
                table: "CinemaMovie");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "CinemaMovie");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "CinemaMovie");

            migrationBuilder.DropSequence(
                name: "MovieSequence");

            migrationBuilder.AlterColumn<int>(
                name: "Identifier",
                table: "TelevisionMovie",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR [MovieSequence]");

            migrationBuilder.AlterColumn<int>(
                name: "Identifier",
                table: "CinemaMovie",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR [MovieSequence]");

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Identifier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainGenreId = table.Column<int>(type: "int", nullable: false),
                    AgeRating = table.Column<int>(type: "int", nullable: false),
                    InternetRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    Plot = table.Column<string>(type: "varchar(max)", nullable: true),
                    Title = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_Pictures_Genres_MainGenreId",
                        column: x => x.MainGenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_MainGenreId",
                table: "Pictures",
                column: "MainGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaMovie_Pictures_Identifier",
                table: "CinemaMovie",
                column: "Identifier",
                principalTable: "Pictures",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TelevisionMovie_Pictures_Identifier",
                table: "TelevisionMovie",
                column: "Identifier",
                principalTable: "Pictures",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

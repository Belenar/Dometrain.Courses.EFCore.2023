using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dometrain.EFCore.API.Migrations
{
    /// <inheritdoc />
    public partial class TablePerHierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TelevisionMovie_Genres_MainGenreId",
                table: "TelevisionMovie");

            migrationBuilder.DropTable(
                name: "CinemaMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TelevisionMovie",
                table: "TelevisionMovie");

            migrationBuilder.DropSequence(
                name: "MovieSequence");

            migrationBuilder.RenameTable(
                name: "TelevisionMovie",
                newName: "Pictures");

            migrationBuilder.RenameIndex(
                name: "IX_TelevisionMovie_MainGenreId",
                table: "Pictures",
                newName: "IX_Pictures_MainGenreId");

            migrationBuilder.AlterColumn<string>(
                name: "ChannelFirstAiredOn",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Identifier",
                table: "Pictures",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR [MovieSequence]")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "GrossRevenue",
                table: "Pictures",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures",
                column: "Identifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Genres_MainGenreId",
                table: "Pictures",
                column: "MainGenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Genres_MainGenreId",
                table: "Pictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "GrossRevenue",
                table: "Pictures");

            migrationBuilder.RenameTable(
                name: "Pictures",
                newName: "TelevisionMovie");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_MainGenreId",
                table: "TelevisionMovie",
                newName: "IX_TelevisionMovie_MainGenreId");

            migrationBuilder.CreateSequence(
                name: "MovieSequence");

            migrationBuilder.AlterColumn<string>(
                name: "ChannelFirstAiredOn",
                table: "TelevisionMovie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Identifier",
                table: "TelevisionMovie",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR [MovieSequence]",
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TelevisionMovie",
                table: "TelevisionMovie",
                column: "Identifier");

            migrationBuilder.CreateTable(
                name: "CinemaMovie",
                columns: table => new
                {
                    Identifier = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [MovieSequence]"),
                    MainGenreId = table.Column<int>(type: "int", nullable: false),
                    AgeRating = table.Column<int>(type: "int", nullable: false),
                    InternetRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    Plot = table.Column<string>(type: "varchar(max)", nullable: true),
                    Title = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    GrossRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaMovie", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_CinemaMovie_Genres_MainGenreId",
                        column: x => x.MainGenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaMovie_MainGenreId",
                table: "CinemaMovie",
                column: "MainGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_TelevisionMovie_Genres_MainGenreId",
                table: "TelevisionMovie",
                column: "MainGenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

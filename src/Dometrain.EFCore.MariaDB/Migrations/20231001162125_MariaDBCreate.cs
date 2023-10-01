using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dometrain.EFCore.MariaDB.Migrations
{
    /// <inheritdoc />
    public partial class MariaDBCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GenreNames",
                columns: table => new
                {
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyToken = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                    table.UniqueConstraint("AK_Genres_Name", x => x.Name);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Identifier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    Plot = table.Column<string>(type: "varchar(4096)", maxLength: 4096, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AgeRating = table.Column<int>(type: "int", nullable: false),
                    InternetRating = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    MainGenreName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GrossRevenue = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    ChannelFirstAiredOn = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Identifier);
                    table.UniqueConstraint("AK_Pictures_Title_ReleaseDate", x => new { x.Title, x.ReleaseDate });
                    table.ForeignKey(
                        name: "FK_Pictures_Genres_MainGenreName",
                        column: x => x.MainGenreName,
                        principalTable: "Genres",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExternalInformations",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ImdbUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RottenTomatoesUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TmdbUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalInformations", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_ExternalInformations_Pictures_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Pictures",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movie_Actor",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie_Actor", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MovieActor_Actor",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActor_Movie",
                        column: x => x.MovieId,
                        principalTable: "Pictures",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Actor_ActorId",
                table: "Movie_Actor",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_AgeRating",
                table: "Pictures",
                column: "AgeRating",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_MainGenreName",
                table: "Pictures",
                column: "MainGenreName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalInformations");

            migrationBuilder.DropTable(
                name: "GenreNames");

            migrationBuilder.DropTable(
                name: "Movie_Actor");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}

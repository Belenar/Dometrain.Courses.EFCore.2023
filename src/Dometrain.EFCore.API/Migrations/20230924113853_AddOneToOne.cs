using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dometrain.EFCore.API.Migrations
{
    /// <inheritdoc />
    public partial class AddOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExternalInformations",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ImdbUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RottenTomatoesUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TmdbUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalInformations");
        }
    }
}

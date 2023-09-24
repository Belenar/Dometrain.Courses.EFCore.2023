using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dometrain.EFCore.API.Migrations
{
    /// <inheritdoc />
    public partial class TablePerType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChannelFirstAiredOn",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "GrossRevenue",
                table: "Pictures");

            migrationBuilder.CreateTable(
                name: "CinemaMovie",
                columns: table => new
                {
                    Identifier = table.Column<int>(type: "int", nullable: false),
                    GrossRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaMovie", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_CinemaMovie_Pictures_Identifier",
                        column: x => x.Identifier,
                        principalTable: "Pictures",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelevisionMovie",
                columns: table => new
                {
                    Identifier = table.Column<int>(type: "int", nullable: false),
                    ChannelFirstAiredOn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelevisionMovie", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_TelevisionMovie_Pictures_Identifier",
                        column: x => x.Identifier,
                        principalTable: "Pictures",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaMovie");

            migrationBuilder.DropTable(
                name: "TelevisionMovie");

            migrationBuilder.AddColumn<string>(
                name: "ChannelFirstAiredOn",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true);

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
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class efmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinema",
                columns: table => new
                {
                    cinemaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    localisation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinema", x => x.cinemaId);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    filmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    duree = table.Column<double>(type: "float", nullable: false),
                    dateRealisation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    prix = table.Column<double>(type: "float", nullable: false),
                    typeFilm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.filmId);
                });

            migrationBuilder.CreateTable(
                name: "Salle",
                columns: table => new
                {
                    idSalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<int>(type: "int", nullable: false),
                    nbPlaces = table.Column<int>(type: "int", nullable: false),
                    cinemaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salle", x => x.idSalle);
                    table.ForeignKey(
                        name: "FK_Salle_Cinema_cinemaId",
                        column: x => x.cinemaId,
                        principalTable: "Cinema",
                        principalColumn: "cinemaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmSalle",
                columns: table => new
                {
                    filmsfilmId = table.Column<int>(type: "int", nullable: false),
                    sallesidSalle = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmSalle", x => new { x.filmsfilmId, x.sallesidSalle });
                    table.ForeignKey(
                        name: "FK_FilmSalle_Film_filmsfilmId",
                        column: x => x.filmsfilmId,
                        principalTable: "Film",
                        principalColumn: "filmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmSalle_Salle_sallesidSalle",
                        column: x => x.sallesidSalle,
                        principalTable: "Salle",
                        principalColumn: "idSalle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projection",
                columns: table => new
                {
                    dateProjection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    salleFk = table.Column<int>(type: "int", nullable: false),
                    filmFk = table.Column<int>(type: "int", nullable: false),
                    typeProjection = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    filmId = table.Column<int>(type: "int", nullable: false),
                    salleidSalle = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projection", x => new { x.filmFk, x.salleFk, x.dateProjection });
                    table.ForeignKey(
                        name: "FK_Projection_Film_filmId",
                        column: x => x.filmId,
                        principalTable: "Film",
                        principalColumn: "filmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projection_Salle_salleidSalle",
                        column: x => x.salleidSalle,
                        principalTable: "Salle",
                        principalColumn: "idSalle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmSalle_sallesidSalle",
                table: "FilmSalle",
                column: "sallesidSalle");

            migrationBuilder.CreateIndex(
                name: "IX_Projection_filmId",
                table: "Projection",
                column: "filmId");

            migrationBuilder.CreateIndex(
                name: "IX_Projection_salleidSalle",
                table: "Projection",
                column: "salleidSalle");

            migrationBuilder.CreateIndex(
                name: "IX_Salle_cinemaId",
                table: "Salle",
                column: "cinemaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmSalle");

            migrationBuilder.DropTable(
                name: "Projection");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Salle");

            migrationBuilder.DropTable(
                name: "Cinema");
        }
    }
}

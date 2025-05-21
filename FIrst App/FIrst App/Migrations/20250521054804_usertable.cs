using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIrst_App.Migrations
{
    /// <inheritdoc />
    public partial class usertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movie_GenreId",
                table: "movie",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_movie_genre_GenreId",
                table: "movie",
                column: "GenreId",
                principalTable: "genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movie_genre_GenreId",
                table: "movie");

            migrationBuilder.DropTable(
                name: "MovieWithGenre");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropIndex(
                name: "IX_movie_GenreId",
                table: "movie");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "movie");

            migrationBuilder.DropColumn(
                name: "MovieFileName",
                table: "movie");

            migrationBuilder.RenameColumn(
                name: "MovieFilePath",
                table: "movie",
                newName: "Genre");
        }
    }
}

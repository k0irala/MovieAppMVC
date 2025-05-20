using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIrst_App.Migrations
{
    /// <inheritdoc />
    public partial class ImagePoster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(

                name: "MovieFilePath",
                table: "movie",
                type:"nvarchar(max)",
                nullable:false,
                defaultValue:""
                );


            migrationBuilder.AddColumn<string>(
                name: "MovieFileName",
                table: "movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movie_genre_GenreId",
                table: "movie");

            migrationBuilder.DropTable(
                name: "MovieWithGenre");

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

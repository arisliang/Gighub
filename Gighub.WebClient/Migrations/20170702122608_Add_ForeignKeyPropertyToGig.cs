using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gighub.WebClient.Migrations
{
    public partial class Add_ForeignKeyPropertyToGig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_Genres_Genre_Id",
                table: "Gigs");

            migrationBuilder.RenameColumn(
                name: "Genre_Id",
                table: "Gigs",
                newName: "GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Gigs_Genre_Id",
                table: "Gigs",
                newName: "IX_Gigs_GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_Genres_GenreId",
                table: "Gigs",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_Genres_GenreId",
                table: "Gigs");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Gigs",
                newName: "Genre_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Gigs_GenreId",
                table: "Gigs",
                newName: "IX_Gigs_Genre_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_Genres_Genre_Id",
                table: "Gigs",
                column: "Genre_Id",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class playlistnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "genre",
                table: "Playlist",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "artist",
                table: "Playlist",
                newName: "Artist");

            migrationBuilder.RenameColumn(
                name: "album",
                table: "Playlist",
                newName: "Album");

            migrationBuilder.AddColumn<string>(
                name: "Imglink",
                table: "Playlist",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Musiclink",
                table: "Playlist",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imglink",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "Musiclink",
                table: "Playlist");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Playlist",
                newName: "genre");

            migrationBuilder.RenameColumn(
                name: "Artist",
                table: "Playlist",
                newName: "artist");

            migrationBuilder.RenameColumn(
                name: "Album",
                table: "Playlist",
                newName: "album");
        }
    }
}

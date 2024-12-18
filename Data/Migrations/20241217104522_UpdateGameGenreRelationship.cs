using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gamedev.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGameGenreRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Genres_GenreId1",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_GenreId1",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GenreId1",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "RPG" },
                    { 4, "Simulation" },
                    { 5, "Strategy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreId",
                table: "Games",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Genres_GenreId",
                table: "Games",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Genres_GenreId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_GenreId",
                table: "Games");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "GenreId",
                table: "Games",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "GenreId1",
                table: "Games",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreId1",
                table: "Games",
                column: "GenreId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Genres_GenreId1",
                table: "Games",
                column: "GenreId1",
                principalTable: "Genres",
                principalColumn: "Id");
        }
    }
}

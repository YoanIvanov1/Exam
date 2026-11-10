using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Exam.Migrations
{
    /// <inheritdoc />
    public partial class seedDataAndBetRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedWinner",
                table: "Matches");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bets",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "Date", "Location", "TeamA", "TeamB" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stadium A", "LR", "G2" },
                    { 2, new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stadium B", "KC", "MKOI" },
                    { 3, new DateTime(2024, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stadium C", "LR", "KC" },
                    { 4, new DateTime(2024, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stadium D", "G2", "MKOI" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name", "Ranking", "Region" },
                values: new object[,]
                {
                    { 1, "LR", 1, "Europe" },
                    { 2, "G2", 2, "Europe" },
                    { 3, "MKOI", 3, "Europe" },
                    { 4, "KC", 4, "Europe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_MatchId",
                table: "Bets",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_UserId",
                table: "Bets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_AspNetUsers_UserId",
                table: "Bets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Matches_MatchId",
                table: "Bets",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_AspNetUsers_UserId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Matches_MatchId",
                table: "Bets");

            migrationBuilder.DropIndex(
                name: "IX_Bets_MatchId",
                table: "Bets");

            migrationBuilder.DropIndex(
                name: "IX_Bets_UserId",
                table: "Bets");

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<string>(
                name: "SelectedWinner",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}

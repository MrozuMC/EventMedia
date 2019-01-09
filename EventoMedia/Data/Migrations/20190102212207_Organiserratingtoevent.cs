using Microsoft.EntityFrameworkCore.Migrations;

namespace EventoMedia.Data.Migrations
{
    public partial class Organiserratingtoevent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganiserID",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "OrganiserRatingID",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganiserRatingID",
                table: "Events",
                column: "OrganiserRatingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_OrganiserRatings_OrganiserRatingID",
                table: "Events",
                column: "OrganiserRatingID",
                principalTable: "OrganiserRatings",
                principalColumn: "OrganiserRatingID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_OrganiserRatings_OrganiserRatingID",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_OrganiserRatingID",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "OrganiserRatingID",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "OrganiserID",
                table: "Events",
                nullable: true);
        }
    }
}

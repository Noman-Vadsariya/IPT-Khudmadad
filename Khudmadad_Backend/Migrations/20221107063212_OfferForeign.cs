using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khudmadad_Backend.Migrations
{
    public partial class OfferForeign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_UsersuserId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_UsersuserId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "UsersuserId",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Offers",
                newName: "freelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_freelancerId",
                table: "Offers",
                column: "freelancerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_freelancerId",
                table: "Offers",
                column: "freelancerId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_freelancerId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_freelancerId",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "freelancerId",
                table: "Offers",
                newName: "userId");

            migrationBuilder.AddColumn<int>(
                name: "UsersuserId",
                table: "Offers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_UsersuserId",
                table: "Offers",
                column: "UsersuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_UsersuserId",
                table: "Offers",
                column: "UsersuserId",
                principalTable: "Users",
                principalColumn: "userId");
        }
    }
}

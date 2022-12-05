using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KhudmadadBackend.Migrations
{
    /// <inheritdoc />
    public partial class FKUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Gig_gigId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_freelancerId",
                table: "Offers");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Gig_gigId",
                table: "Offers",
                column: "gigId",
                principalTable: "Gig",
                principalColumn: "gigId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_freelancerId",
                table: "Offers",
                column: "freelancerId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Gig_gigId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_freelancerId",
                table: "Offers");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Gig_gigId",
                table: "Offers",
                column: "gigId",
                principalTable: "Gig",
                principalColumn: "gigId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_freelancerId",
                table: "Offers",
                column: "freelancerId",
                principalTable: "Users",
                principalColumn: "userId");
        }
    }
}

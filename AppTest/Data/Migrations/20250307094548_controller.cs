using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class controller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseQuestion",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuestionRedaction_reponse_correct",
                table: "BaseQuestion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "reponse_correct",
                table: "BaseQuestion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "reponse_possible",
                table: "BaseQuestion",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseQuestion");

            migrationBuilder.DropColumn(
                name: "QuestionRedaction_reponse_correct",
                table: "BaseQuestion");

            migrationBuilder.DropColumn(
                name: "reponse_correct",
                table: "BaseQuestion");

            migrationBuilder.DropColumn(
                name: "reponse_possible",
                table: "BaseQuestion");
        }
    }
}

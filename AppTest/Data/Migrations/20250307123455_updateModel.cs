using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "BaseResultat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Note",
                table: "BaseResultat",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nom",
                table: "BaseResultat");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "BaseResultat");
        }
    }
}

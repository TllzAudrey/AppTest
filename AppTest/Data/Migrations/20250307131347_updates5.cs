using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class updates5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GestionnaireId",
                table: "Candidat",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GestionnaireId",
                table: "BaseTest",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "fk_id_entreprise",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidat_GestionnaireId",
                table: "Candidat",
                column: "GestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseTest_GestionnaireId",
                table: "BaseTest",
                column: "GestionnaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseTest_AspNetUsers_GestionnaireId",
                table: "BaseTest",
                column: "GestionnaireId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidat_AspNetUsers_GestionnaireId",
                table: "Candidat",
                column: "GestionnaireId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseTest_AspNetUsers_GestionnaireId",
                table: "BaseTest");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidat_AspNetUsers_GestionnaireId",
                table: "Candidat");

            migrationBuilder.DropIndex(
                name: "IX_Candidat_GestionnaireId",
                table: "Candidat");

            migrationBuilder.DropIndex(
                name: "IX_BaseTest_GestionnaireId",
                table: "BaseTest");

            migrationBuilder.DropColumn(
                name: "GestionnaireId",
                table: "Candidat");

            migrationBuilder.DropColumn(
                name: "GestionnaireId",
                table: "BaseTest");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "fk_id_entreprise",
                table: "AspNetUsers");
        }
    }
}

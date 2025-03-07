using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseQuestion_Test_TestId",
                table: "BaseQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseReponse_ResultatTest_ResultatTestId",
                table: "BaseReponse");

            migrationBuilder.DropTable(
                name: "ReponseCode");

            migrationBuilder.DropTable(
                name: "ReponseQCM");

            migrationBuilder.DropTable(
                name: "ReponseRedaction");

            migrationBuilder.DropTable(
                name: "ResultatTest");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "ResultatCampagne");

            migrationBuilder.DropTable(
                name: "Campagne");

            migrationBuilder.AddColumn<int>(
                name: "CampagneId",
                table: "BaseTest",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseTest",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseResultat",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ResultatCampagneId",
                table: "BaseResultat",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fk_id_campagne",
                table: "BaseResultat",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fk_id_test",
                table: "BaseResultat",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseReponse",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReponseQCM_reponse_candidat",
                table: "BaseReponse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReponseRedaction_reponse_candidat",
                table: "BaseReponse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "reponse_candidat",
                table: "BaseReponse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseTest_CampagneId",
                table: "BaseTest",
                column: "CampagneId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseResultat_ResultatCampagneId",
                table: "BaseResultat",
                column: "ResultatCampagneId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseQuestion_BaseTest_TestId",
                table: "BaseQuestion",
                column: "TestId",
                principalTable: "BaseTest",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseReponse_BaseResultat_ResultatTestId",
                table: "BaseReponse",
                column: "ResultatTestId",
                principalTable: "BaseResultat",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseResultat_BaseResultat_ResultatCampagneId",
                table: "BaseResultat",
                column: "ResultatCampagneId",
                principalTable: "BaseResultat",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseTest_BaseTest_CampagneId",
                table: "BaseTest",
                column: "CampagneId",
                principalTable: "BaseTest",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseQuestion_BaseTest_TestId",
                table: "BaseQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseReponse_BaseResultat_ResultatTestId",
                table: "BaseReponse");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseResultat_BaseResultat_ResultatCampagneId",
                table: "BaseResultat");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseTest_BaseTest_CampagneId",
                table: "BaseTest");

            migrationBuilder.DropIndex(
                name: "IX_BaseTest_CampagneId",
                table: "BaseTest");

            migrationBuilder.DropIndex(
                name: "IX_BaseResultat_ResultatCampagneId",
                table: "BaseResultat");

            migrationBuilder.DropColumn(
                name: "CampagneId",
                table: "BaseTest");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseTest");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseResultat");

            migrationBuilder.DropColumn(
                name: "ResultatCampagneId",
                table: "BaseResultat");

            migrationBuilder.DropColumn(
                name: "fk_id_campagne",
                table: "BaseResultat");

            migrationBuilder.DropColumn(
                name: "fk_id_test",
                table: "BaseResultat");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseReponse");

            migrationBuilder.DropColumn(
                name: "ReponseQCM_reponse_candidat",
                table: "BaseReponse");

            migrationBuilder.DropColumn(
                name: "ReponseRedaction_reponse_candidat",
                table: "BaseReponse");

            migrationBuilder.DropColumn(
                name: "reponse_candidat",
                table: "BaseReponse");

            migrationBuilder.CreateTable(
                name: "Campagne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campagne", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReponseCode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reponse_candidat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReponseCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReponseQCM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reponse_candidat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReponseQCM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReponseRedaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reponse_candidat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReponseRedaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultatCampagne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_id_campagne = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultatCampagne", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampagneId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Test_Campagne_CampagneId",
                        column: x => x.CampagneId,
                        principalTable: "Campagne",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResultatTest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResultatCampagneId = table.Column<int>(type: "int", nullable: true),
                    fk_id_test = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultatTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultatTest_ResultatCampagne_ResultatCampagneId",
                        column: x => x.ResultatCampagneId,
                        principalTable: "ResultatCampagne",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResultatTest_ResultatCampagneId",
                table: "ResultatTest",
                column: "ResultatCampagneId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_CampagneId",
                table: "Test",
                column: "CampagneId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseQuestion_Test_TestId",
                table: "BaseQuestion",
                column: "TestId",
                principalTable: "Test",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseReponse_ResultatTest_ResultatTestId",
                table: "BaseReponse",
                column: "ResultatTestId",
                principalTable: "ResultatTest",
                principalColumn: "Id");
        }
    }
}

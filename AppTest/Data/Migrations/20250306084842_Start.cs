using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class Start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseTest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fk_id_entreprise = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseTest", x => x.Id);
                });

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
                name: "Entreprise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entreprise", x => x.Id);
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
                name: "BaseResultat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseTestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseResultat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseResultat_BaseTest_BaseTestId",
                        column: x => x.BaseTestId,
                        principalTable: "BaseTest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Candidat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseTestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidat_BaseTest_BaseTestId",
                        column: x => x.BaseTestId,
                        principalTable: "BaseTest",
                        principalColumn: "Id");
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
                    fk_id_test = table.Column<int>(type: "int", nullable: true),
                    ResultatCampagneId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "BaseQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    intitule = table.Column<int>(type: "int", nullable: true),
                    TestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseQuestion_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BaseReponse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_id_test = table.Column<int>(type: "int", nullable: true),
                    fk_id_question = table.Column<int>(type: "int", nullable: true),
                    ResultatTestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseReponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseReponse_ResultatTest_ResultatTestId",
                        column: x => x.ResultatTestId,
                        principalTable: "ResultatTest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseQuestion_TestId",
                table: "BaseQuestion",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseReponse_ResultatTestId",
                table: "BaseReponse",
                column: "ResultatTestId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseResultat_BaseTestId",
                table: "BaseResultat",
                column: "BaseTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidat_BaseTestId",
                table: "Candidat",
                column: "BaseTestId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultatTest_ResultatCampagneId",
                table: "ResultatTest",
                column: "ResultatCampagneId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_CampagneId",
                table: "Test",
                column: "CampagneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseQuestion");

            migrationBuilder.DropTable(
                name: "BaseReponse");

            migrationBuilder.DropTable(
                name: "BaseResultat");

            migrationBuilder.DropTable(
                name: "Candidat");

            migrationBuilder.DropTable(
                name: "Entreprise");

            migrationBuilder.DropTable(
                name: "ReponseCode");

            migrationBuilder.DropTable(
                name: "ReponseQCM");

            migrationBuilder.DropTable(
                name: "ReponseRedaction");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "ResultatTest");

            migrationBuilder.DropTable(
                name: "BaseTest");

            migrationBuilder.DropTable(
                name: "Campagne");

            migrationBuilder.DropTable(
                name: "ResultatCampagne");
        }
    }
}

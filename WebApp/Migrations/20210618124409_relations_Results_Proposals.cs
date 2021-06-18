using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class relations_Results_Proposals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Questionnaires_QuestionnaireId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_QuestionnaireId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "QuestionnaireId",
                table: "Results");

            migrationBuilder.AlterColumn<int>(
                name: "Timer",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ProposalResult",
                columns: table => new
                {
                    ProposalsId = table.Column<int>(type: "int", nullable: false),
                    ResultsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposalResult", x => new { x.ProposalsId, x.ResultsId });
                    table.ForeignKey(
                        name: "FK_ProposalResult_Proposals_ProposalsId",
                        column: x => x.ProposalsId,
                        principalTable: "Proposals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProposalResult_Results_ResultsId",
                        column: x => x.ResultsId,
                        principalTable: "Results",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProposalResult_ResultsId",
                table: "ProposalResult",
                column: "ResultsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProposalResult");

            migrationBuilder.AddColumn<int>(
                name: "QuestionnaireId",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Timer",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Results_QuestionnaireId",
                table: "Results",
                column: "QuestionnaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Questionnaires_QuestionnaireId",
                table: "Results",
                column: "QuestionnaireId",
                principalTable: "Questionnaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

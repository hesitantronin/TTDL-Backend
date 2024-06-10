using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTDL_Backend.Migrations
{
    public partial class remodeledDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chairs_Patients_PatientId",
                table: "Chairs");

            migrationBuilder.DropIndex(
                name: "IX_Chairs_PatientId",
                table: "Chairs");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Chairs",
                newName: "CurrentPatientId");

            migrationBuilder.AddColumn<string>(
                name: "CurrentChairId",
                table: "Patients",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_CurrentChairId",
                table: "Patients",
                column: "CurrentChairId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Chairs_CurrentChairId",
                table: "Patients",
                column: "CurrentChairId",
                principalTable: "Chairs",
                principalColumn: "ChairId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Chairs_CurrentChairId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_CurrentChairId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CurrentChairId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "CurrentPatientId",
                table: "Chairs",
                newName: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Chairs_PatientId",
                table: "Chairs",
                column: "PatientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Chairs_Patients_PatientId",
                table: "Chairs",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

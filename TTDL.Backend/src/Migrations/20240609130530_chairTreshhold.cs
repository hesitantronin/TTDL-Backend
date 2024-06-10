using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTDL_Backend.Migrations
{
    public partial class chairTreshhold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chair_Patients_PatientId",
                table: "Chair");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurement_Chair_ChairId",
                table: "Measurement");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurement_Patients_CurrentPatientId",
                table: "Measurement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Measurement",
                table: "Measurement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chair",
                table: "Chair");

            migrationBuilder.RenameTable(
                name: "Measurement",
                newName: "Measurements");

            migrationBuilder.RenameTable(
                name: "Chair",
                newName: "Chairs");

            migrationBuilder.RenameIndex(
                name: "IX_Measurement_CurrentPatientId",
                table: "Measurements",
                newName: "IX_Measurements_CurrentPatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Measurement_ChairId",
                table: "Measurements",
                newName: "IX_Measurements_ChairId");

            migrationBuilder.RenameIndex(
                name: "IX_Chair_PatientId",
                table: "Chairs",
                newName: "IX_Chairs_PatientId");

            migrationBuilder.AddColumn<decimal>(
                name: "WeightTreshhold",
                table: "Chairs",
                type: "numeric(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Measurements",
                table: "Measurements",
                column: "MeasurementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chairs",
                table: "Chairs",
                column: "ChairId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chairs_Patients_PatientId",
                table: "Chairs",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Chairs_ChairId",
                table: "Measurements",
                column: "ChairId",
                principalTable: "Chairs",
                principalColumn: "ChairId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Patients_CurrentPatientId",
                table: "Measurements",
                column: "CurrentPatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chairs_Patients_PatientId",
                table: "Chairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Chairs_ChairId",
                table: "Measurements");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Patients_CurrentPatientId",
                table: "Measurements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Measurements",
                table: "Measurements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chairs",
                table: "Chairs");

            migrationBuilder.DropColumn(
                name: "WeightTreshhold",
                table: "Chairs");

            migrationBuilder.RenameTable(
                name: "Measurements",
                newName: "Measurement");

            migrationBuilder.RenameTable(
                name: "Chairs",
                newName: "Chair");

            migrationBuilder.RenameIndex(
                name: "IX_Measurements_CurrentPatientId",
                table: "Measurement",
                newName: "IX_Measurement_CurrentPatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Measurements_ChairId",
                table: "Measurement",
                newName: "IX_Measurement_ChairId");

            migrationBuilder.RenameIndex(
                name: "IX_Chairs_PatientId",
                table: "Chair",
                newName: "IX_Chair_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Measurement",
                table: "Measurement",
                column: "MeasurementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chair",
                table: "Chair",
                column: "ChairId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chair_Patients_PatientId",
                table: "Chair",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurement_Chair_ChairId",
                table: "Measurement",
                column: "ChairId",
                principalTable: "Chair",
                principalColumn: "ChairId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurement_Patients_CurrentPatientId",
                table: "Measurement",
                column: "CurrentPatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

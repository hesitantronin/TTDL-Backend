using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTDL_Backend.Migrations
{
    public partial class requirementsChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Chairs_CurrentChairId",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentChairId",
                table: "Patients",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Chairs_CurrentChairId",
                table: "Patients",
                column: "CurrentChairId",
                principalTable: "Chairs",
                principalColumn: "ChairId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Chairs_CurrentChairId",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentChairId",
                table: "Patients",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Chairs_CurrentChairId",
                table: "Patients",
                column: "CurrentChairId",
                principalTable: "Chairs",
                principalColumn: "ChairId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

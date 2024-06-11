using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTDL_Backend.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BatteryState",
                table: "Chairs",
                newName: "LowBattery");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentPatientId",
                table: "Chairs",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LowBattery",
                table: "Chairs",
                newName: "BatteryState");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentPatientId",
                table: "Chairs",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}

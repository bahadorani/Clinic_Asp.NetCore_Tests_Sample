using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Persistence.Migrations
{
    public partial class ModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Insurances_InsuranceId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.AddColumn<int>(
                name: "InstallmentCount",
                table: "Visits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "InstallmentPay",
                table: "Visits",
                type: "decimal",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceId",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "IdentityCart",
                table: "Patients",
                type: "varchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentityNumber",
                table: "Insureds",
                type: "varchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_IdentityCart",
                table: "Patients",
                column: "IdentityCart",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Insureds_IdentityNumber",
                table: "Insureds",
                column: "IdentityNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Insureds_InsuranceId",
                table: "Patients",
                column: "InsuranceId",
                principalTable: "Insureds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Insureds_InsuranceId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_IdentityCart",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Insureds_IdentityNumber",
                table: "Insureds");

            migrationBuilder.DropColumn(
                name: "InstallmentCount",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "InstallmentPay",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "IdentityCart",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "IdentityNumber",
                table: "Insureds");

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuredId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insurances_Insureds_InsuredId",
                        column: x => x.InsuredId,
                        principalTable: "Insureds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_InsuredId",
                table: "Insurances",
                column: "InsuredId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Insurances_InsuranceId",
                table: "Patients",
                column: "InsuranceId",
                principalTable: "Insurances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

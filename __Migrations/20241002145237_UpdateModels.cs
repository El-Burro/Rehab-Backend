using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RehabBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Plans_PlanId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Clients_ClientId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Patients_PatientId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_PatientId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Patients_ClientId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_PlanId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Exercises");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Plans",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Exercises",
                table: "Plans",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Plans",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Patients",
                table: "Plans",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Patients",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plans",
                table: "Patients",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exercises",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Exercises",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plans",
                table: "Exercises",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Patients",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exercises",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Patients",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Plans",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Plans",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Patients",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Plans",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Plans",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Patients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exercises",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Exercises",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "Exercises",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_PatientId",
                table: "Plans",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ClientId",
                table: "Patients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_PlanId",
                table: "Exercises",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Plans_PlanId",
                table: "Exercises",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Clients_ClientId",
                table: "Patients",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Patients_PatientId",
                table: "Plans",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

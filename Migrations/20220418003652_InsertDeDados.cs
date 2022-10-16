using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleDeFrotaWebApi.Migrations
{
    public partial class InsertDeDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cnh",
                table: "tbl_motor",
                type: "varchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.InsertData(
                table: "tbl_motor",
                columns: new[] { "motor_id", "ativo", "cnh", "nome", "validadeCNH" },
                values: new object[,]
                {
                    { "f50449ce-eecb-4a9b-9a60-55f28e75f231", true, "12345678", "Wesley Santos", new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "0f683f4f-4474-43b2-a97f-4788c068cc71", true, "87654321", "Victoria São Felippe", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tbl_veicl",
                columns: new[] { "veicl_id", "ano", "modelo", "placa" },
                values: new object[,]
                {
                    { "13e9aab5-7e2a-471a-bbd7-44082774216a", 2020, "Onix", "QQD-2D51" },
                    { "d01f14be-e33f-49fb-a11d-5edba7a8de84", 2022, "Prima", "VIC-5K31" }
                });

            migrationBuilder.InsertData(
                table: "tbl_motr_veicl",
                columns: new[] { "motor_id", "veicl_id" },
                values: new object[] { "f50449ce-eecb-4a9b-9a60-55f28e75f231", "13e9aab5-7e2a-471a-bbd7-44082774216a" });

            migrationBuilder.InsertData(
                table: "tbl_motr_veicl",
                columns: new[] { "motor_id", "veicl_id" },
                values: new object[] { "0f683f4f-4474-43b2-a97f-4788c068cc71", "d01f14be-e33f-49fb-a11d-5edba7a8de84" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_motr_veicl",
                keyColumns: new[] { "motor_id", "veicl_id" },
                keyValues: new object[] { "0f683f4f-4474-43b2-a97f-4788c068cc71", "d01f14be-e33f-49fb-a11d-5edba7a8de84" });

            migrationBuilder.DeleteData(
                table: "tbl_motr_veicl",
                keyColumns: new[] { "motor_id", "veicl_id" },
                keyValues: new object[] { "f50449ce-eecb-4a9b-9a60-55f28e75f231", "13e9aab5-7e2a-471a-bbd7-44082774216a" });

            migrationBuilder.DeleteData(
                table: "tbl_motor",
                keyColumn: "motor_id",
                keyValue: "0f683f4f-4474-43b2-a97f-4788c068cc71");

            migrationBuilder.DeleteData(
                table: "tbl_motor",
                keyColumn: "motor_id",
                keyValue: "f50449ce-eecb-4a9b-9a60-55f28e75f231");

            migrationBuilder.DeleteData(
                table: "tbl_veicl",
                keyColumn: "veicl_id",
                keyValue: "13e9aab5-7e2a-471a-bbd7-44082774216a");

            migrationBuilder.DeleteData(
                table: "tbl_veicl",
                keyColumn: "veicl_id",
                keyValue: "d01f14be-e33f-49fb-a11d-5edba7a8de84");

            migrationBuilder.AlterColumn<string>(
                name: "cnh",
                table: "tbl_motor",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)");
        }
    }
}

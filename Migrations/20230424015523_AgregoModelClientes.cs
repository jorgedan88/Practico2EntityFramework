﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practico2HDP.Migrations
{
    /// <inheritdoc />
    public partial class AgregoModelClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConcesionarioID",
                table: "Moto",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    CUIT = table.Column<string>(type: "TEXT", nullable: false),
                    ConsumidorFinal = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moto_ConcesionarioID",
                table: "Moto",
                column: "ConcesionarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Moto_Concesionario_ConcesionarioID",
                table: "Moto",
                column: "ConcesionarioID",
                principalTable: "Concesionario",
                principalColumn: "ConcesionarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moto_Concesionario_ConcesionarioID",
                table: "Moto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Moto_ConcesionarioID",
                table: "Moto");

            migrationBuilder.DropColumn(
                name: "ConcesionarioID",
                table: "Moto");
        }
    }
}

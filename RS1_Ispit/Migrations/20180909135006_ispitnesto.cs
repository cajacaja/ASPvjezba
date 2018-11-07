using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_Ispit_asp.net_core.Migrations
{
    public partial class ispitnesto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaturskiIspit_Nastavnik_IspitivacId",
                table: "MaturskiIspit");

            migrationBuilder.DropForeignKey(
                name: "FK_MaturskiIspit_Predmet_PredmetId",
                table: "MaturskiIspit");

            migrationBuilder.DropForeignKey(
                name: "FK_MaturskiIspit_SkolskaGodina_SkolskaGodinaId",
                table: "MaturskiIspit");

            migrationBuilder.DropForeignKey(
                name: "FK_MaturskiIspitStavka_MaturskiIspit_MaturskiIspitId",
                table: "MaturskiIspitStavka");

            migrationBuilder.RenameColumn(
                name: "MaturskiIspitId",
                table: "MaturskiIspitStavka",
                newName: "MaturskiIspitiD");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MaturskiIspitStavka",
                newName: "MaturskiIspitStavkaId");

            migrationBuilder.RenameIndex(
                name: "IX_MaturskiIspitStavka_MaturskiIspitId",
                table: "MaturskiIspitStavka",
                newName: "IX_MaturskiIspitStavka_MaturskiIspitiD");

            migrationBuilder.RenameColumn(
                name: "PredmetId",
                table: "MaturskiIspit",
                newName: "PredmetID");

            migrationBuilder.RenameColumn(
                name: "SkolskaGodinaId",
                table: "MaturskiIspit",
                newName: "OdjeljenjeId");

            migrationBuilder.RenameColumn(
                name: "IspitivacId",
                table: "MaturskiIspit",
                newName: "NastavnikID");

            migrationBuilder.RenameColumn(
                name: "Datum",
                table: "MaturskiIspit",
                newName: "DatumIspita");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MaturskiIspit",
                newName: "MaturskiIspitId");

            migrationBuilder.RenameIndex(
                name: "IX_MaturskiIspit_PredmetId",
                table: "MaturskiIspit",
                newName: "IX_MaturskiIspit_PredmetID");

            migrationBuilder.RenameIndex(
                name: "IX_MaturskiIspit_SkolskaGodinaId",
                table: "MaturskiIspit",
                newName: "IX_MaturskiIspit_OdjeljenjeId");

            migrationBuilder.RenameIndex(
                name: "IX_MaturskiIspit_IspitivacId",
                table: "MaturskiIspit",
                newName: "IX_MaturskiIspit_NastavnikID");

            migrationBuilder.AddColumn<bool>(
                name: "Oslobodjen",
                table: "MaturskiIspitStavka",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_MaturskiIspit_Nastavnik_NastavnikID",
                table: "MaturskiIspit",
                column: "NastavnikID",
                principalTable: "Nastavnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaturskiIspit_Odjeljenje_OdjeljenjeId",
                table: "MaturskiIspit",
                column: "OdjeljenjeId",
                principalTable: "Odjeljenje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaturskiIspit_Predmet_PredmetID",
                table: "MaturskiIspit",
                column: "PredmetID",
                principalTable: "Predmet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaturskiIspitStavka_MaturskiIspit_MaturskiIspitiD",
                table: "MaturskiIspitStavka",
                column: "MaturskiIspitiD",
                principalTable: "MaturskiIspit",
                principalColumn: "MaturskiIspitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaturskiIspit_Nastavnik_NastavnikID",
                table: "MaturskiIspit");

            migrationBuilder.DropForeignKey(
                name: "FK_MaturskiIspit_Odjeljenje_OdjeljenjeId",
                table: "MaturskiIspit");

            migrationBuilder.DropForeignKey(
                name: "FK_MaturskiIspit_Predmet_PredmetID",
                table: "MaturskiIspit");

            migrationBuilder.DropForeignKey(
                name: "FK_MaturskiIspitStavka_MaturskiIspit_MaturskiIspitiD",
                table: "MaturskiIspitStavka");

            migrationBuilder.DropColumn(
                name: "Oslobodjen",
                table: "MaturskiIspitStavka");

            migrationBuilder.RenameColumn(
                name: "MaturskiIspitiD",
                table: "MaturskiIspitStavka",
                newName: "MaturskiIspitId");

            migrationBuilder.RenameColumn(
                name: "MaturskiIspitStavkaId",
                table: "MaturskiIspitStavka",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_MaturskiIspitStavka_MaturskiIspitiD",
                table: "MaturskiIspitStavka",
                newName: "IX_MaturskiIspitStavka_MaturskiIspitId");

            migrationBuilder.RenameColumn(
                name: "PredmetID",
                table: "MaturskiIspit",
                newName: "PredmetId");

            migrationBuilder.RenameColumn(
                name: "OdjeljenjeId",
                table: "MaturskiIspit",
                newName: "SkolskaGodinaId");

            migrationBuilder.RenameColumn(
                name: "NastavnikID",
                table: "MaturskiIspit",
                newName: "IspitivacId");

            migrationBuilder.RenameColumn(
                name: "DatumIspita",
                table: "MaturskiIspit",
                newName: "Datum");

            migrationBuilder.RenameColumn(
                name: "MaturskiIspitId",
                table: "MaturskiIspit",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_MaturskiIspit_PredmetID",
                table: "MaturskiIspit",
                newName: "IX_MaturskiIspit_PredmetId");

            migrationBuilder.RenameIndex(
                name: "IX_MaturskiIspit_OdjeljenjeId",
                table: "MaturskiIspit",
                newName: "IX_MaturskiIspit_SkolskaGodinaId");

            migrationBuilder.RenameIndex(
                name: "IX_MaturskiIspit_NastavnikID",
                table: "MaturskiIspit",
                newName: "IX_MaturskiIspit_IspitivacId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaturskiIspit_Nastavnik_IspitivacId",
                table: "MaturskiIspit",
                column: "IspitivacId",
                principalTable: "Nastavnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaturskiIspit_Predmet_PredmetId",
                table: "MaturskiIspit",
                column: "PredmetId",
                principalTable: "Predmet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaturskiIspit_SkolskaGodina_SkolskaGodinaId",
                table: "MaturskiIspit",
                column: "SkolskaGodinaId",
                principalTable: "SkolskaGodina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaturskiIspitStavka_MaturskiIspit_MaturskiIspitId",
                table: "MaturskiIspitStavka",
                column: "MaturskiIspitId",
                principalTable: "MaturskiIspit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

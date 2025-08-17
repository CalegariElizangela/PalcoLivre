using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PalcoLivre.Migrations
{
    /// <inheritdoc />
    public partial class AddHoraInicialHoraFinalToAgendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraFinal",
                table: "Agendamentos",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraInicial",
                table: "Agendamentos",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraFinal",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "HoraInicial",
                table: "Agendamentos");
        }
    }
}

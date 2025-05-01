using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskPomodoro.API.Migrations
{
    /// <inheritdoc />
    public partial class AddSessaoPomodoro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SessoesPomodoro",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TarefaID = table.Column<int>(type: "INTEGER", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    Concluido = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessoesPomodoro", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SessoesPomodoro_Tarefas_TarefaID",
                        column: x => x.TarefaID,
                        principalTable: "Tarefas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessoesPomodoro_TarefaID",
                table: "SessoesPomodoro",
                column: "TarefaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessoesPomodoro");
        }
    }
}

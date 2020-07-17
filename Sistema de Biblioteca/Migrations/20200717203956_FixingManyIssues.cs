using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_de_Biblioteca.Migrations
{
    public partial class FixingManyIssues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_EnderecoId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_TelefoneId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_EnderecoId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TelefoneId",
                table: "Alunos");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Telefones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Telefones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Enderecos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Enderecos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EmprestimoViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataLimiteEntrega = table.Column<DateTime>(nullable: false),
                    DataEntrega = table.Column<DateTime>(nullable: true),
                    AlunoId = table.Column<int>(nullable: false),
                    LivroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmprestimoViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EnderecoId",
                table: "Funcionarios",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_TelefoneId",
                table: "Funcionarios",
                column: "TelefoneId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_EnderecoId",
                table: "Alunos",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TelefoneId",
                table: "Alunos",
                column: "TelefoneId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmprestimoViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_EnderecoId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_TelefoneId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_EnderecoId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TelefoneId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Enderecos");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EnderecoId",
                table: "Funcionarios",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_TelefoneId",
                table: "Funcionarios",
                column: "TelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_EnderecoId",
                table: "Alunos",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TelefoneId",
                table: "Alunos",
                column: "TelefoneId");
        }
    }
}

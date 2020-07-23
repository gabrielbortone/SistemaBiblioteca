using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_de_Biblioteca.Migrations
{
    public partial class ApplyingSomeFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_AspNetUsers_AccountId1",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Enderecos_EnderecoId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Telefones_TelefoneId",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "EmprestimoViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_AccountId1",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_EnderecoId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_TelefoneId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "AccountId1",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "TelefoneId",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Telefones",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_FuncionarioId",
                table: "Telefones",
                column: "FuncionarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_FuncionarioId",
                table: "Enderecos",
                column: "FuncionarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FuncionarioId",
                table: "AspNetUsers",
                column: "FuncionarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Funcionarios_FuncionarioId",
                table: "AspNetUsers",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Funcionarios_FuncionarioId",
                table: "Enderecos",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Funcionarios_FuncionarioId",
                table: "Telefones",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Funcionarios_FuncionarioId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Funcionarios_FuncionarioId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Funcionarios_FuncionarioId",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Telefones_FuncionarioId",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_FuncionarioId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FuncionarioId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Tipo",
                table: "Telefones",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AccountId1",
                table: "Funcionarios",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TelefoneId",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EmprestimoViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataLimiteEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LivroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmprestimoViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_AccountId1",
                table: "Funcionarios",
                column: "AccountId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_AspNetUsers_AccountId1",
                table: "Funcionarios",
                column: "AccountId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Enderecos_EnderecoId",
                table: "Funcionarios",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Telefones_TelefoneId",
                table: "Funcionarios",
                column: "TelefoneId",
                principalTable: "Telefones",
                principalColumn: "TelefoneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

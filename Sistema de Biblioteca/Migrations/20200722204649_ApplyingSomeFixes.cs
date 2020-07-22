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

            migrationBuilder.DropTable(
                name: "EmprestimoViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_AccountId1",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "AccountId1",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Funcionarios_FuncionarioId",
                table: "AspNetUsers");

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

            migrationBuilder.AddColumn<string>(
                name: "AccountId1",
                table: "Funcionarios",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_AspNetUsers_AccountId1",
                table: "Funcionarios",
                column: "AccountId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

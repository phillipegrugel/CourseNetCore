﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.Api.Migrations
{
    public partial class initMySql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Registro = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunoCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunoCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoCursos_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    CargaHoraria = table.Column<int>(nullable: false),
                    ProfessorId = table.Column<int>(nullable: false),
                    PrerequisitoId = table.Column<int>(nullable: true),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PrerequisitoId",
                        column: x => x.PrerequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Nota = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunoDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(6226), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marta", "Kent", "33225555" },
                    { 2, true, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(7697), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paula", "Isabela", "3354288" },
                    { 3, true, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(7754), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", "Antonia", "55668899" },
                    { 4, true, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(7760), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luiza", "Maria", "6565659" },
                    { 5, true, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(7765), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", "Machado", "565685415" },
                    { 6, true, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(7772), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pedro", "Alvares", "456454545" },
                    { 7, true, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(7776), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Paulo", "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Tecnologia da Informação" },
                    { 2, "Sistema de Informação" },
                    { 3, "Ciência da Computação" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2021, 12, 28, 16, 4, 56, 361, DateTimeKind.Local).AddTicks(2593), "Lauro", 1, "Oliveira", null },
                    { 2, true, null, new DateTime(2021, 12, 28, 16, 4, 56, 362, DateTimeKind.Local).AddTicks(346), "Roberto", 2, "Soares", null },
                    { 3, true, null, new DateTime(2021, 12, 28, 16, 4, 56, 362, DateTimeKind.Local).AddTicks(403), "Ronaldo", 3, "Marconi", null },
                    { 4, true, null, new DateTime(2021, 12, 28, 16, 4, 56, 362, DateTimeKind.Local).AddTicks(405), "Rodrigo", 4, "Carvalho", null },
                    { 5, true, null, new DateTime(2021, 12, 28, 16, 4, 56, 362, DateTimeKind.Local).AddTicks(407), "Alexandre", 5, "Montanha", null }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[,]
                {
                    { 1, 0, 1, "Matemática", null, 1 },
                    { 2, 0, 2, "Matemática", null, 1 },
                    { 3, 0, 3, "Física", null, 2 },
                    { 4, 0, 1, "Português", null, 3 },
                    { 5, 0, 1, "Inglês", null, 4 },
                    { 6, 0, 2, "Inglês", null, 4 },
                    { 7, 0, 3, "Inglês", null, 4 },
                    { 8, 0, 1, "Programação", null, 5 },
                    { 9, 0, 2, "Programação", null, 5 },
                    { 10, 0, 3, "Programação", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[,]
                {
                    { 2, 1, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9401), null },
                    { 4, 5, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9415), null },
                    { 2, 5, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9407), null },
                    { 1, 5, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9400), null },
                    { 7, 4, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9427), null },
                    { 6, 4, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9423), null },
                    { 5, 4, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9416), null },
                    { 4, 4, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9414), null },
                    { 1, 4, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9370), null },
                    { 7, 3, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9426), null },
                    { 5, 5, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9417), null },
                    { 6, 3, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9420), null },
                    { 7, 2, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9425), null },
                    { 6, 2, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9419), null },
                    { 3, 2, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9409), null },
                    { 2, 2, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9403), null },
                    { 1, 2, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(8922), null },
                    { 7, 1, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9424), null },
                    { 6, 1, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9418), null },
                    { 4, 1, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9412), null },
                    { 3, 1, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9408), null },
                    { 3, 3, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9410), null },
                    { 7, 5, null, new DateTime(2021, 12, 28, 16, 4, 56, 365, DateTimeKind.Local).AddTicks(9428), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoCursos_CursoId",
                table: "AlunoCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDisciplinas_DisciplinaId",
                table: "AlunoDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PrerequisitoId",
                table: "Disciplinas",
                column: "PrerequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoCursos");

            migrationBuilder.DropTable(
                name: "AlunoDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}

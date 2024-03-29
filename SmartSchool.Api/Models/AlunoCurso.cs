﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Api.Models
{
    public class AlunoCurso
    {
        public AlunoCurso(int alunoId, int cursoId) 
        {
            this.AlunoId = alunoId;
            this.CursoId = cursoId;
        }

        public AlunoCurso() { }

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
    }
}

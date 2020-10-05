using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorNotas.Dominio
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Unidade { get; set; }
        public string Turma { get; set; }
        public int Serie { get; set; }
        public string Vestibular { get; set; }
        public string FormaIngresso { get; set; }
        public DateTime DataMatricula { get; set; }
        public char Situacao { get; set; }

        //Relacionamento n x n
        public List<AlunoCurso> AlunosCursos { get; set; }
    }
}

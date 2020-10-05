using GerenciadorNotas.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorNotas.Repositorio
{
    public class GerenciadorNotasContext : DbContext
    {
        public GerenciadorNotasContext(DbContextOptions<GerenciadorNotasContext> optionsBuilder) : base(optionsBuilder)
        { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AlunoCurso> AlunoCursos { get; set; }
        public DbSet<Curso> Cursos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Dizendo para o EF que estamos usando n x n, que tem uma chave composta, que ALUNO e CURSO sao a chave composta
            modelBuilder.Entity<AlunoCurso>(entity =>
            {
                //Tem chave? a chave composta é composta de AlunoId e CursoId, mas poderia ser varias
                entity.HasKey(e => new { e.AlunoId, e.CursoId });
            });
        }
    }
}

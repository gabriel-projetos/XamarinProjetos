using Microsoft.EntityFrameworkCore;

namespace WebApplication1.models
{
    //A maneira recomendada para trabalhar com o contexto é definir uma classe que deriva de DbContext e expõe as propriedades de DbSet que representam as coleções das entidades especificadas no contexto.
    public class TarefaContext : DbContext
    {
        //A classe DbContext administra os objetos entidades durante o tempo de execução, o que inclui preencher objetos com dados de um banco de dados, controlar alterações, e persistir dados para o banco de dados.
        public TarefaContext(DbContextOptions<TarefaContext> options)
            : base(options)
        { }
        public DbSet<TarefaItem> TarefaItens { get; set; }
    }
}

 using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FuncionariosAPIService.Models
{
    public class FuncionarioDBContext : DbContext
    {
        public FuncionarioDBContext() : base("name=FuncionarioDBContext")
        { }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
using GerenciadorNotas.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorNotas.Repositorio.Interfaces
{
    public interface IEFCoreRepositorio
    {
        void Add<T>(T entity) where T : class;

        Task<Aluno> GetDadosAlunoByRA(string ra);

        Task<bool> SaveChangedAsync();
    }
}

using GerenciadorNotas.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorNotas.Repositorio.Interfaces
{
    public class EFCoreRepositorio : IEFCoreRepositorio
    {
        public readonly GerenciadorNotasContext _context;

        public EFCoreRepositorio(GerenciadorNotasContext gerenciadorNotasContext)
        {
            _context = gerenciadorNotasContext;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task<Aluno> GetDadosAlunoByRA(string ra)
        {
            IQueryable<Aluno> query = _context.Alunos;
            query = query.AsNoTracking().OrderBy(x => x.RA);
            return await query.FirstOrDefaultAsync(x => x.RA == ra);
        }

        public async Task<bool> SaveChangedAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

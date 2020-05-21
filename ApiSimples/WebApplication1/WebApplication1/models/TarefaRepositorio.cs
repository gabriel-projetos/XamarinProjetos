using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.models
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        //O contexto de banco de dados é definido em uma variável de classe(_context)
        private readonly TarefaContext _context;


        //Aqui estamos passando a instância TarefaContext para o construtor.
        public TarefaRepositorio(TarefaContext context)
        {
            _context = context;
            Add(new TarefaItem { Nome = "Item1" , EstaCompleta = true});
            Add(new TarefaItem { Nome = "Item2" });
        }
        public IEnumerable<TarefaItem> GetAll()
        {
            return _context.TarefaItens.ToList();
        }
        public void Add(TarefaItem item)
        {
            _context.TarefaItens.Add(item);
            _context.SaveChanges();
        }
        public TarefaItem Find(long key)
        {
            return _context.TarefaItens.FirstOrDefault(t => t.Chave == key);
        }
        public void Remove(long key)
        {
            var entity = _context.TarefaItens.First(t => t.Chave == key);
            _context.TarefaItens.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(TarefaItem item)
        {
            _context.TarefaItens.Update(item);
            _context.SaveChanges();
        }
    }
}

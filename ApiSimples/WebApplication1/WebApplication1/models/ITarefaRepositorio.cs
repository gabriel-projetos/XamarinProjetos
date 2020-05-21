using System.Collections.Generic;

namespace WebApplication1.models
{
    public interface ITarefaRepositorio
    {
        //Nesta interface estamos definindo métodos para realizar um CRUD básico.Vamos agora implementar essa interface.
        void Add(TarefaItem item);
        IEnumerable<TarefaItem> GetAll();
        TarefaItem Find(long key);
        void Remove(long key);
        void Update(TarefaItem item);
    }
}

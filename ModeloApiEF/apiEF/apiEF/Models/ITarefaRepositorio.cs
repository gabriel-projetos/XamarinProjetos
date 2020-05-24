using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiEF.Models
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

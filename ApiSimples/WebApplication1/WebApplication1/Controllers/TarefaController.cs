using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    //Obtenha o template string no atributo route do controlador :  [Route ("api / [controller]"]]
    //Substitua [controller] pelo nome do controlador, que é o nome da classe do controlador menos o sufixo
    [ApiController]
    [Route("api/tarefas")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }


        //[HttpGet] especifica um método HTTP GET e o caminho da URL para cada método é construido da seguinte maneira:  
        [HttpGet]
        public IEnumerable<TarefaItem> GetAll()
        {
            //O método GetAll retorna um IEnumerable e o MVC automaticamente serializa o objeto para JSON e escreve o JSON no corpo da mensagem response.  
            return _tarefaRepositorio.GetAll();
        }

        //{id}" é uma variável de espaço reservado para o ID do item tarefa. Quando o método GetById for chamado, ele atribuirá o valor de "{id}" na URL para o parâmetro id do método.
        //Name = "GetTarefa" cria uma rota nomeada e permite que você vincule a esta rota uma Resposta HTTP.

        //GetById 
        //Se nenhum item coincidir com o ID requisitado, o método retorna o erro 404. Isto é feito no código pelo retorno de NotFound.

        //Se houver correspondência com o ID requisistado, o método retorna 200 com um JSON no corpo do response.Isto é feito no código pelo retorno de um ObjectResult.
        [HttpGet("{id}", Name = "GetTarefa")]
        public IActionResult GetById(long id)
        {
            var item = _tarefaRepositorio.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TarefaItem item)
        {
            //o Atributo [FromBody] informa ao MVC para obter o valor do item tarefa a partir do corpo da requisição HTTP.


            if (item == null)
            {
                return BadRequest();
            }
            _tarefaRepositorio.Add(item);
            return CreatedAtRoute("GetTarefa", new { id = item.Chave }, item);
        }


        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TarefaItem item)
        {
            if (item == null || item.Chave != id)
            {
                return BadRequest();
            }
            var tarefa = _tarefaRepositorio.Find(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            tarefa.EstaCompleta = item.EstaCompleta;
            tarefa.Nome = item.Nome;
            _tarefaRepositorio.Update(tarefa);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _tarefaRepositorio.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            _tarefaRepositorio.Remove(id);
            return new NoContentResult();
        }
    }
}

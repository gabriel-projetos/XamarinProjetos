using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.models
{
    public class TarefaItem
    {
        //Key, que é um identificador exclusivo
        //DatabaseGenerated especifica que o banco de dados gerará a chave(em vez do aplicativo)
        //DatabaseGeneratedOption.Identity especifica que o banco de dados deve gerar chaves inteiras quando uma linha for inserida.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Chave { get; set; }
        public string Nome { get; set; }
        public bool EstaCompleta { get; set; }
    }
}

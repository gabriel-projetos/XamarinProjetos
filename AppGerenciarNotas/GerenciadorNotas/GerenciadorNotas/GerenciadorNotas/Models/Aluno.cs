using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorNotas.Models
{
    public class Aluno
    {
        /********* Referente a tela MeuCadastro **************/
        public int id { get; set; }
        public string nome { get; set; }
        public string rg { get; set; }
        public string cpf { get; set; }

        /********* Referente a tela DadosCurso **************/

        public string curso { get; set; }
        public string unidade { get; set; }
        public string turma { get; set; }
    }
}

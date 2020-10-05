using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorNotas.Dominio
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string CertidaoReservista { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public string Naturalidade { get; set; }
        public string NomeMae { get; set; }
        public string Email { get; set; }
        public string TelefoneResidencial { get; set; }
        public string TelefoneCelular { get; set; }
        public string EnderecoCompleto { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }

        //Relacionamento n x n
        public List<AlunoCurso> MyProperty { get; set; }
    }
}

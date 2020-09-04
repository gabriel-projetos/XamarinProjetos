using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class Produto
    {
        //public int Id { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
    }
}
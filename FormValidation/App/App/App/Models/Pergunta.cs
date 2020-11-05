using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class Pergunta : List<Alternativa>
    {
        public int NumPergunta { get; set; }
        public string DescPergunta { get; set; }

        public Pergunta(string descPergunta)
        {
            this.DescPergunta = descPergunta;
        }
    }


    public class Alternativa
    {
        public int NumAlternativa { get; set; }
        public string DescAlternativa { get; set; }
        public int TipoPergunta { get; set; }
    }




    public enum TipoPergunta
    {
        RespostaCurta,
        RespostaLonga,
        Alternativa,
        Selecao,
        Numerica
    }
}

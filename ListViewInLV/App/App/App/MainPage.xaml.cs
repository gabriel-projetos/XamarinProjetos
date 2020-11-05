using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App
{
    public partial class MainPage : ContentPage
    {
        public class Pergunta
        {
            public int numQuestao { get; set; }
            public string Descricao { get; set; }
            public int TipoQuestao { get; set; }
            public List<Alternativa> Alternativas { get; set; }
        }

        public enum ETipoQuestao
        {
            RespostaCurta,
            RespostaLonga,
            Selecao
        }

        public class Alternativa
        {
            public string DescricaoAlt { get; set; }
        }

        private List<Pergunta> _perguntas;

        public List<Pergunta> Perguntas
        {
            get { return _perguntas; }
            set { _perguntas = value; }
        }

        
        public MainPage()
        {
            Perguntas = new List<Pergunta>();
            InitializeComponent();
            


            Perguntas.Add(new Pergunta
            {
                Descricao = "Qual seu nome?",
                numQuestao = 1,
                TipoQuestao = (int)ETipoQuestao.Selecao,
                Alternativas = new List<Alternativa>
                {
                    new Alternativa { DescricaoAlt = "Gabriel"},
                    new Alternativa { DescricaoAlt = "Fernanda"},
                    new Alternativa { DescricaoAlt = "Rafael"}
                }
            });

            Perguntas.Add(new Pergunta
            {
                Descricao = "Qual sua idade?",
                numQuestao = 2,
                TipoQuestao = (int)ETipoQuestao.Selecao,
                Alternativas = new List<Alternativa>
                {
                    new Alternativa { DescricaoAlt = "18"},
                    new Alternativa { DescricaoAlt = "20"},
                    new Alternativa { DescricaoAlt = "2"},
                    new Alternativa { DescricaoAlt = "25"},
                    new Alternativa { DescricaoAlt = "32"}
                }
            });


            ListView_Perguntas.ItemsSource = Perguntas;
        }
    }
}

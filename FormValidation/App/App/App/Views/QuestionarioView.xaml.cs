using App.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionarioView : ContentPage
    {
        public QuestionarioView()
        {
            InitializeComponent();
            ListaPerguntas.ItemsSource = GetPerguntas();
            //ntryy.Text
        }

        private List<Pergunta> GetPerguntas()
        {
            int count = 1;
            return new List<Pergunta>
            {
                //Resposta Curta
                new Pergunta($"{count++}) Qual seu nome?")
                { 
                    new Alternativa { TipoPergunta = (int)TipoPergunta.RespostaCurta }
                },
                new Pergunta($"{count++}) Qual seu Sobrenome?")
                {
                    new Alternativa { TipoPergunta = (int)TipoPergunta.RespostaCurta }
                },
                new Pergunta($"{count++}) Qual seu ultimo nome?")
                {
                    new Alternativa { TipoPergunta = (int)TipoPergunta.RespostaCurta }
                },
                new Pergunta($"{count++}) Qual o nome do seu cachorro?")
                {
                    new Alternativa { TipoPergunta = (int)TipoPergunta.RespostaCurta }
                },
                //resposta Longa
                new Pergunta($"{count++}) Se descreva?")
                {
                    new Alternativa { TipoPergunta = (int)TipoPergunta.RespostaLonga }
                },
                //Resposta Númerica
                new Pergunta($"{count++}) Qual sua idade?")
                {
                    new Alternativa { TipoPergunta = (int)TipoPergunta.Numerica }
                },
                //Alternativa
                new Pergunta($"{count++}) Qual o resultado de 5 + 3?")
                {
                    new Alternativa {DescAlternativa = "8", TipoPergunta = (int)TipoPergunta.Alternativa},
                    new Alternativa {DescAlternativa = "3", TipoPergunta = (int)TipoPergunta.Alternativa},
                    new Alternativa {DescAlternativa = "32", TipoPergunta = (int)TipoPergunta.Alternativa},
                    new Alternativa {DescAlternativa = "15", TipoPergunta = (int)TipoPergunta.Alternativa}
                },
                //Alternativa
                new Pergunta($"{count++}) Qual seu estado ?")
                {
                    new Alternativa {DescAlternativa = "SP",
                    TipoPergunta = (int)TipoPergunta.Alternativa},
                    new Alternativa {DescAlternativa = "RJ",
                    TipoPergunta = (int)TipoPergunta.Alternativa},
                    new Alternativa {DescAlternativa = "PI",
                    TipoPergunta = (int)TipoPergunta.Alternativa}
                },
                //Seleção
                new Pergunta($"{count++}) Qual o resultado da expressão 5 + 9 ?")
                {
                    new Alternativa {DescAlternativa = "1 + 13",
                    TipoPergunta = (int)TipoPergunta.Selecao},
                    new Alternativa {DescAlternativa = "2 + 12",
                    TipoPergunta = (int)TipoPergunta.Selecao},
                    new Alternativa {DescAlternativa = "4 + 5",
                    TipoPergunta = (int)TipoPergunta.Selecao},
                    new Alternativa {DescAlternativa = "4 + 1",
                    TipoPergunta = (int)TipoPergunta.Selecao},
                    new Alternativa {DescAlternativa = "4 + 8",
                    TipoPergunta = (int)TipoPergunta.Selecao}
                },

            };
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var teste = ListaPerguntas.ItemsSource;
        }
    }
}
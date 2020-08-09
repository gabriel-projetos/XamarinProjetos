using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            ListaFuncionarios.ItemsSource = GetFuncionarios();
        }
        List<Grupo> GetFuncionarios()
        {
            return new List<Grupo>
            {
                new Grupo("Presidente", "CEO", "Presidente da Empresa")
                {
                    new Pessoa {Nome = "Gabriel", IsRequired = true, Rank = 8},
                },
                new Grupo("Diretores", "Dir", "Diretor da Empresa")
                {
                    new Pessoa {Nome = "Gabriel", IsRequired = true, Rank = 8},
                    new Pessoa {Nome = "Fernando", IsRequired = false, Rank = 3}
                },
                new Grupo("Gerentes", "Ger", "Gerente da Empresa")
                {
                    new Pessoa {Nome = "Felipe", IsRequired = true, Rank = 7},
                    new Pessoa {Nome = "Judas", IsRequired = false, Rank = 9}
                },
                new Grupo("Funcionarios", "Func", "Funcionarios da Empresa")
                {
                    new Pessoa {Nome = "Felipe", IsRequired = false},
                    new Pessoa {Nome = "Fernanda", IsRequired = false},
                    new Pessoa {Nome = "Gabi", IsRequired = false},
                    new Pessoa {Nome = "Jessica", IsRequired = false},
                    new Pessoa {Nome = "Sheila", IsRequired = false},
                    new Pessoa {Nome = "Dani", IsRequired = false},
                    new Pessoa {Nome = "Debora", IsRequired = true, Rank = 6},
                    new Pessoa {Nome = "Douglas", IsRequired = false },
                    new Pessoa {Nome = "Gabriel", IsRequired = false },
                    new Pessoa {Nome = "Eduardo", IsRequired = false },
                    new Pessoa {Nome = "Cecilia", IsRequired = false },
                    new Pessoa {Nome = "Eder", IsRequired = false },
                    new Pessoa {Nome = "Maria", IsRequired = false },
                    new Pessoa {Nome = "Vitor", IsRequired = false }
                }
            };
        }
        public class Grupo : List<Pessoa>
        {
            public string Titulo { get; set; }
            public string TituloCurto { get; set; }
            public string Descricao { get; set; }

            public Grupo(string titulo, string tituloCurto, string descricao)
            {
                this.Titulo = titulo;
                this.TituloCurto = tituloCurto;
                this.Descricao = descricao;
            }
        }
        public class Pessoa
        {
            public string Nome { get; set; }
            public bool IsRequired { get; set; }
            public int Rank { get; set; }
        }
    }
}

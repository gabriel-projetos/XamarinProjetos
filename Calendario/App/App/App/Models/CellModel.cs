using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.Models
{
    public class CellModel
    {
        public int Coluna { get; set; }
        public int Linha { get; set; }
        public Color BackgroundColor { get; set; }
        public Color TextColor { get; set; }
        public ICommand TapCommand { get; set; }
        public ICommand ScrollCommand { get; set; }

        public DateTime Dia { get; set; }
        public DadosDia dados { get; set; }
    }
    public class DadosDia
    {
        public string DiaValor { get; set; }
        public Days DiaDaSemana { get; set; }
    }
    public enum Days
    {
        Domingo = 0,
        Segunda = 1,
        Terca = 2,
        Quarta = 3,
        Quinta = 4,
        Sexta = 5,
        Sabado = 6
    }
}

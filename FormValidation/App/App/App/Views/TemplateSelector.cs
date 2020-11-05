using App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.Views
{
    public class TemplateSelector : DataTemplateSelector
    {
        public DataTemplate RespCurtaTemplate { get; set; }
        public DataTemplate RespLongaTemplate { get; set; }
        public DataTemplate AlternativaTemplate { get; set; }
        public DataTemplate SelecaoTemplate { get; set; }
        public DataTemplate NumeroTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            Alternativa alternativa = item as Alternativa;
            if (alternativa.TipoPergunta == (int)TipoPergunta.RespostaCurta)
            {
                return RespCurtaTemplate;
            }
            else if (alternativa.TipoPergunta == (int)TipoPergunta.RespostaLonga)
            {
                return RespLongaTemplate;
            }
            else if (alternativa.TipoPergunta == (int)TipoPergunta.Alternativa)
            {
                return AlternativaTemplate;
            }
            else if (alternativa.TipoPergunta == (int)TipoPergunta.Selecao)
            {
                return SelecaoTemplate;
            }
            else
            {
                return NumeroTemplate;
            }
        }
    }
}

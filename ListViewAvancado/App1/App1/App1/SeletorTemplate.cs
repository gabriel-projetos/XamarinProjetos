using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static App1.MainPage;

namespace App1
{
    public class SeletorTemplate : DataTemplateSelector
    {
        DataTemplate ItemPessoaRequired;
        DataTemplate ItemPessoaNotRequired;

        public SeletorTemplate()
        {
            ItemPessoaRequired = new DataTemplate(typeof(Templates.ItemPessoaObrigatorioViewCell));
            ItemPessoaNotRequired = new DataTemplate(typeof(Templates.ItemPessoaNaoObrigatorioViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            Pessoa pessoa = item as Pessoa;

            if (pessoa.IsRequired)
            {
                return ItemPessoaRequired;
            }
            else
            {
                return ItemPessoaNotRequired;
            }
        }
    }
}

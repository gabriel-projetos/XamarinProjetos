using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.Lib
{
    //Passamos no Generic o componente que estaremos implementando o Behavior
    //Todo behavior herda de behavior
    public class MaiusculoBehavior : Behavior<Entry>
    {

        //precissamos sobreescrever dois metodos para criar um behavior
        //Acrescimo/adicionar o comportamento/informação a um controle da tela        
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            //bindable é um entry
            //Vinculando o behavior
            bindable.TextChanged += MaiusculoAction;
        }


        //quando o comportamento/informação não é mais necessária, remover o comportamento
        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);

            //Removendo o evento
            bindable.TextChanged -= MaiusculoAction;
        }

        //Todo evento como parametro gera um OBJECT e um EventArgs de acordo com a propriedade, no caso do TextChanged é um TextChangedEventArgs
        private void MaiusculoAction(object sender, TextChangedEventArgs args)
        {
            if(!string.IsNullOrEmpty(args.NewTextValue))
            {
                ((Entry)sender).Text = args.NewTextValue.ToUpper();
            } 
        }

    }
}

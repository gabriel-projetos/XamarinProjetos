using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.Lib
{
    //Uma trigger herda de TriggerAction
    public class EmailValidoTrigger : TriggerAction<Entry>
    {
        //Somos obrigados a implementar o metodo Invoke
        protected override void Invoke(Entry sender)
        {                        
            if(sender.Text.IndexOf("@") >= 0)
            {
                sender.TextColor = Color.Green;
            }
            else
            {
                sender.TextColor = Color.Red;
            }
        }
    }
}

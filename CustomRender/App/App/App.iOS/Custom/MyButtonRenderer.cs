using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Custom;
using App.iOS.Custom;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


//Primeiro TypeOf é a classe no projeto compartilhado
//Segundo typeOf é a classe na plataforma especifica
[assembly: ExportRenderer(typeof(MyButton), typeof(MyButtonRenderer))]
namespace App.iOS.Custom
{
    [Obsolete]
    public class MyButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            //Control representa o botão nativo do android
            if (Control != null)
            {
                Control.Layer.CornerRadius = 10; // this value vary as per your desire
                Control.ClipsToBounds = true;
            }
        }
    }
}
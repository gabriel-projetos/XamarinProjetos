using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App.Custom;
using App.Droid.Custom;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

//Primeiro TypeOf é a classe no projeto compartilhado
//Segundo typeOf é a classe na plataforma especifica
[assembly:ExportRenderer(typeof(MyButton), typeof(MyButtonRenderer))]
namespace App.Droid.Custom
{
    [Obsolete]
    public class MyButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            //Control representa o botão nativo do android
            if(Control != null)
            {
                Control.SetBackgroundResource(Resource.Drawable.button_round);
                //Control.SetBackgroundColor(Android.Graphics.Color.LightSkyBlue);
            }
        }
    }
}
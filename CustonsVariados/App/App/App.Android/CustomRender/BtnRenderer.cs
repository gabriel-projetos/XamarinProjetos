using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App.CustomRender;
using App.Droid.CustomRender;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ButtonRender), typeof(BtnRenderer))]
namespace App.Droid.CustomRender
{
    public class BtnRenderer : ButtonRenderer
    {
        public BtnRenderer(Android.Content.Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                //Control.SetBackgroundColor(Android.Graphics.Color.Red);
                Control.SetBackgroundResource(Resource.Drawable.iconfinder_Home_132240);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app.Tipo_pagina.Carousel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //A page tem que ser compatival com a page no XML
    public partial class IntroduçãoApp : CarouselPage
    {
        public IntroduçãoApp()
        {
            InitializeComponent();
        }
    }
}
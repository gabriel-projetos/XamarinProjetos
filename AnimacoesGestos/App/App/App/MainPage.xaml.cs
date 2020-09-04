using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public MainPage()
        {
            InitializeComponent();

            /*          Tipos de gestos/Gesture      */
            // Tap - Clique/Toque
            // Pinch - efeito de pinça, aumentar uma imagem etc
            // Pan - Mover objetos
            PanGestureRecognizer pan = new PanGestureRecognizer();
            pan.PanUpdated += PanGestureRecognizer_Pan;

            myLabel.GestureRecognizers.Add(pan);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Tapped", "Label clicada: " + count++, "ok");
        }

        private void PanGestureRecognizer_Pan(object sender, PanUpdatedEventArgs e)
        {
            //Se ainda está movendo
            if(e.StatusType == GestureStatus.Running)
            {
                Rectangle rect = new Rectangle(e.TotalX, e.TotalY, 200, 25);

                //quem vai receber é a label
                AbsoluteLayout.SetLayoutBounds(myLabel, rect);
                AbsoluteLayout.SetLayoutFlags(myLabel, AbsoluteLayoutFlags.None);
                //myLabel.Text = e.TotalX.ToString() + " - " + e.TotalY.ToString();
            }
        }
    }
}

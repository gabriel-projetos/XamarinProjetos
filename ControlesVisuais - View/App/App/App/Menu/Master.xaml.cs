using App.Controles;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : MasterDetailPage
    {
        public Master()
        {
            InitializeComponent();

            BindingContext = new MasterModel();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMensagens();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CancelarMensagens();
        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<ActivityIndicatorPage>(this, "GoActivity", (msg) =>
            {
                //App.Current.MainPage = new Navigation.Pagina1();
                Detail = new ActivityIndicatorPage();

                //Esconder a master
                IsPresented = false;
            });

            MessagingCenter.Subscribe<ProgressBarPage>(this, "GoProgressBar", (msg) =>
            {
                Detail = new ProgressBarPage();
                //Esconder a master
                IsPresented = false;
            });

            MessagingCenter.Subscribe<BoxViewPage>(this, "GoBoxView", (msg) =>
            {
                Detail = new BoxViewPage();
                //Esconder a master
                IsPresented = false;
            });

            MessagingCenter.Subscribe<LabelPage>(this, "GoLabel", (msg) =>
            {
                Detail = new LabelPage();
                //Esconder a master
                IsPresented = false;
            });

            MessagingCenter.Subscribe<ButtonPage>(this, "GoButton", (msg) =>
            {
                Detail = new ButtonPage();
                //Esconder a master
                IsPresented = false;
            });
            
            MessagingCenter.Subscribe<EntryEditorPage>(this, "GoEntryEditor", (msg) =>
            {
                Detail = new EntryEditorPage();
                //Esconder a master
                IsPresented = false;
            }); 

            MessagingCenter.Subscribe<DatePickerPage>(this, "GoDatePicker", (msg) =>
            {
                Detail = new DatePickerPage();
                //Esconder a master
                IsPresented = false;
            });
            
            MessagingCenter.Subscribe<TimePickerPage>(this, "GoTimePicker", (msg) =>
            {
                Detail = new TimePickerPage();
                //Esconder a master
                IsPresented = false;
            });







            MessagingCenter.Subscribe<SliderStepperPage>(this, "GoSliderStepper", (msg) =>
            {
                Detail = new SliderStepperPage();
                //Esconder a master
                IsPresented = false;
            });
        }

        private void CancelarMensagens()
        {
            MessagingCenter.Unsubscribe<ActivityIndicatorPage>(this, "GoActivity");
            MessagingCenter.Unsubscribe<ProgressBarPage>(this, "GoProgressBar");
            MessagingCenter.Unsubscribe<BoxViewPage>(this, "GoBoxView");
            MessagingCenter.Unsubscribe<LabelPage>(this, "GoLabel");
            MessagingCenter.Unsubscribe<ButtonPage>(this, "GoButton");
            MessagingCenter.Unsubscribe<EntryEditorPage>(this, "GoEntryEditor");
            MessagingCenter.Unsubscribe<DatePickerPage>(this, "GoDatePicker");
            MessagingCenter.Unsubscribe<DatePickerPage>(this, "GoTimePicker");

            MessagingCenter.Unsubscribe<SliderStepperPage>(this, "GoSliderStepper");
        }
    }
}
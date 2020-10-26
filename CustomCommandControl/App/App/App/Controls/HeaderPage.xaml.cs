using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;

namespace App.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeaderPage : ContentView
    {
        public event EventHandler Clicked;

        //Convenção de nomenclatura das propriedades
        //https://docs.microsoft.com/pt-br/xamarin/xamarin-forms/xaml/bindable-properties#Creating_a_Property
        public HeaderPage()
        {
            InitializeComponent();
            CriarComando();

            //backButton.SetBinding(Button.CommandProperty, new Binding("CommandBack", source: this));
            //menuLateral.SetBinding(Button.CommandProperty, new Binding("CommandAux", source: this));
            menuLateral.SetBinding(Button.CommandParameterProperty, new Binding("CommandParameter", source: this));
            backButton.SetBinding(Button.CommandParameterProperty, new Binding("CommandParameter", source: this));
        }

        private void CriarComando()
        {         

            //var gestureRecognizerBack = new TapGestureRecognizer();
            //gestureRecognizerBack.Tapped += (s, e) => {
            //    CommandBack = new Command(() =>
            //    {
            //        if (CommandBack != null && CommandBack.CanExecute(CommandParameter))
            //        {
            //            CommandBack.Execute(CommandParameter);
            //        }
            //    });

            //};
            //backButton.GestureRecognizers.Add(gestureRecognizerBack);

            //this.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() =>
            //    {
            //        //if (frame.IsVisible)
            //        //{
            //        Clicked?.Invoke(this, EventArgs.Empty);

            //        if (CommandAux != null)
            //        {
            //            if (CommandAux.CanExecute(CommandParameter))
            //                CommandAux.Execute(CommandParameter);
            //        }
            //        //}
            //    })
            //});
        }

        #region CommandMenuAux
        public static readonly BindableProperty CommandAuxProperty = BindableProperty.Create
            (
                propertyName: "CommandAux",
                typeof(ICommand),
                typeof(HeaderPage),
                null
            );
        public ICommand CommandAux
        {
            get { return (ICommand)GetValue(CommandAuxProperty); }
            set { SetValue(CommandAuxProperty, value); }
        }
        #endregion

        #region CommandBackButon
        public static readonly BindableProperty CommandBackProperty = BindableProperty.Create
            (
                propertyName: "CommandBack",
                typeof(ICommand),
                typeof(HeaderPage),
                null
            );
        public ICommand CommandBack
        {
            get { return (ICommand)GetValue(CommandBackProperty); }
            set { SetValue(CommandBackProperty, value); }
        }
        #endregion

        #region CommandParameter
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create
            (
                propertyName: "CommandParameter",
                typeof(object),
                typeof(HeaderPage),
                null
            );

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageButton : ContentView
    {
        public event EventHandler Clicked;

        public ImageButton()
        {
            InitializeComponent();

            innerLabel.SetBinding(Label.TextProperty, new Binding("ButtonText", source: this));
            innerImage.SetBinding(Image.SourceProperty, new Binding("Source", source: this));
            frame.SetBinding(Frame.IsVisibleProperty, new Binding("IsVisibleBotao", source: this));

            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    if (frame.IsVisible)
                    {
                        Clicked?.Invoke(this, EventArgs.Empty);

                        if(Command != null)
                        {
                            if (Command.CanExecute(CommandParameter))
                                Command.Execute(CommandParameter);
                        }
                    }
                })
            });

        }

        #region BotãoVisivel
        public static readonly BindableProperty IsVisiblePropertyy = BindableProperty.Create(
                propertyName: "IsVisibleBotao",
                returnType: typeof(bool),
                declaringType: typeof(ImageButton),
                defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: IsVisibleButton
            );

        private static void IsVisibleButton(BindableObject bindable, object oldValue, object newValue)
        {
            var myControl = (ImageButton)bindable;
            myControl.frame.IsVisible = (bool)newValue;
        }

        public bool IsVisibleBotao
        {
            get => (bool)GetValue(IsVisiblePropertyy);
            set => SetValue(IsVisiblePropertyy, value);
        }
        #endregion

        #region TextoBotao
        public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create
            (
                propertyName: "ButtonText",
                typeof(string),
                typeof(ImageButton),
                default(string)
            );

        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }
        #endregion

        #region Command
        public static readonly BindableProperty CommandProperty = BindableProperty.Create
            (
                propertyName: "Command",
                typeof(ICommand),
                typeof(ImageButton),
                null
            );

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        #endregion

        #region CommandParameter
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create
            (
                propertyName: "CommandParameter",
                typeof(object),
                typeof(ImageButton),
                null
            );

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        #endregion

        #region ImageSource
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create
            (
                propertyName: "Source",
                typeof(ImageSource),
                typeof(ImageButton),
                default(ImageSource)
            );

        public ImageSource Source
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        #endregion
    }
}
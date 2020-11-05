using App.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomEntryPage : ContentPage
    {
        public CustomEntryPage()
        {
            InitializeComponent();
            User = new User();
            //BindingContext = new MainPageViewModel();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            User.FirstName.NotValidMessageError = "Name is required";
            User.FirstName.IsNotValid = string.IsNullOrEmpty(User.FirstName.Name);

            User.Email.NotValidMessageError = "Email is required";
            User.Email.IsNotValid = string.IsNullOrEmpty(User.Email.Name);


            if (string.IsNullOrEmpty(User.Password.Name))
            {
                User.Password.NotValidMessageError = "Password is required";
                User.Password.IsNotValid = true;
            }
        }
        public User User { get; set; }
    }

    public class User : INotifyPropertyChanged
    {
        public Field FirstName { get; set; } = new Field();
        public Field Email { get; set; } = new Field();
        public Field Password { get; set; } = new Field();

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class Field : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public bool IsNotValid { get; set; }
        public string NotValidMessageError { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
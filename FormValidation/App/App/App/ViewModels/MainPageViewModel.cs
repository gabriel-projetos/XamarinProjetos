using App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        //public User User { get; set; }
        public bool ErrorMessageVisiliby { get; set; }
        public ICommand OnValidationCommand { get; set; }


        private string _name;

        public string Name
        {
            get { return _name; }
            set 
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _notValidMessageError;

        public string NotValidMessageError
        {
            get { return _notValidMessageError; }
            set
            {
                _notValidMessageError = value;
                OnPropertyChanged();
            }
        }

        private bool _isNotValid;

        public bool IsNotValid
        {
            get { return _isNotValid; }
            set
            {
                _isNotValid = value;
                OnPropertyChanged();
            }
        }

        private string _senha;

        public string Senha
        {
            get { return _senha; }
            set
            {
                _senha = value;
                OnPropertyChanged();
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel()
        {
            //User = new User();

            OnValidationCommand = new Command((obj) =>
            {
                //User.FirstName.NotValidMessageError = "Name is required";
                //OnPropertyChanged(nameof(User.FirstName.NotValidMessageError));

                //User.FirstName.IsNotValid = string.IsNullOrEmpty(User.FirstName.Name);
                //OnPropertyChanged(nameof(User.FirstName.IsNotValid));

                //User.Email.NotValidMessageError = "Email is required";
                //OnPropertyChanged(nameof(User.Email.NotValidMessageError));

                //User.Email.IsNotValid = string.IsNullOrEmpty(User.Email.Name);
                //OnPropertyChanged(nameof(User.Email.IsNotValid));


                if (string.IsNullOrEmpty(Senha))
                {
                    NotValidMessageError = "Password is required";
                    IsNotValid = true;
                }
                if (string.IsNullOrEmpty(Email))
                {
                    NotValidMessageError = "E-mail is required";
                    IsNotValid = true;
                }
                if (string.IsNullOrEmpty(Name))
                {
                    NotValidMessageError = "Password is required";
                    IsNotValid = true;
                }
                else
                {
                    IsNotValid = false;
                }

            });
        }
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

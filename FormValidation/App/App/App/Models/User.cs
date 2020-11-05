using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App.Models
{
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public Field FirstName { get; set; } = new Field();
        public Field Email { get; set; } = new Field();
        public Field Password { get; set; } = new Field();
    }

    public class Field : INotifyPropertyChanged
    {
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public string Name { get; set; }
        public bool IsNotValid { get; set; }
        public string NotValidMessageError { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

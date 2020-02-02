using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace app1_testeDrive.Converters
{
    class AgendamentoConfirmadoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            //Convertendo o value para boolean para entao retornar uma cor
            bool confirmado = (bool)value;

            if(confirmado)
            {
                return Color.Black;
            }
            else
            {
                return Color.Red;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

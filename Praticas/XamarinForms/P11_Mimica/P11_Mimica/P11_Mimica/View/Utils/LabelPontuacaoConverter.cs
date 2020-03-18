using System;
using System.Globalization;
using Xamarin.Forms;

namespace P11_Mimica.View.Utils
{
    internal class LabelPontuacaoConverter : IValueConverter
    {
        //View > ViewModel(dado)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte b) {
                if (b != 0) {
                    return $"Pontuação: {b}";
                }
            }
            return "Palavra";
        }

        //ViewModel > View
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
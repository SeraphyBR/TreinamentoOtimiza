using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;

namespace P12_NossoChat.ViewModel
{
    public class BaseViewModel
    {
        public Color MainColor { get; set; } = Color.FromHex("#5ED055");
        public Color SecondaryColor { get; set; } = Color.White;
    }
}

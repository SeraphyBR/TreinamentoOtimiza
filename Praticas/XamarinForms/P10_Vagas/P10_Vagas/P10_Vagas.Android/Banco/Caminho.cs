using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using P10_Vagas.Banco;
using P10_Vagas.Droid.Banco;

[assembly:Dependency(typeof(Caminho))]
namespace P10_Vagas.Droid.Banco
{
    public class Caminho : ICaminho
    {
        public string GetPath(string DBFilename)
        {
            var pathFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(pathFolder, DBFilename);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using P10_Vagas.iOS.Banco;
using P10_Vagas.Banco;
using Xamarin.Forms;


[assembly:Dependency(typeof(Caminho))]
namespace P10_Vagas.iOS.Banco
{
    public class Caminho : ICaminho
    {
        public string GetPath(string DBFilename)
        {
            var pathFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(pathFolder, "..", "Library", DBFilename);
        }
    }
}
using P10_Vagas.Banco;
using P10_Vagas.UWP.Banco;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(Caminho))]

namespace P10_Vagas.UWP.Banco
{
    public class Caminho : ICaminho
    {
        public string GetPath(string DBFilename)
        {
            var pathFolder = ApplicationData.Current.LocalFolder.Path;
            return System.IO.Path.Combine(pathFolder, DBFilename);
        }
    }
}
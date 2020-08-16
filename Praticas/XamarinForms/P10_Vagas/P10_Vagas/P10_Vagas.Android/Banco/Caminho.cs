using P10_Vagas.Banco;
using P10_Vagas.Droid.Banco;
using Xamarin.Forms;

[assembly: Dependency(typeof(Caminho))]

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
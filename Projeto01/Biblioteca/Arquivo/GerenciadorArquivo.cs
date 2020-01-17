using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Biblioteca.Arquivo
{
    public class GerenciadorArquivo
    {
        readonly static string caminhoBase = "C:\\Users\\luiz.santos\\Documents\\";

        public static void GravarArquivo(string filename, string texto)
        {
            string caminho = caminhoBase + filename + ".txt";
            if (File.Exists(caminho))
            {
                using(StreamWriter sw = File.AppendText(caminho))
                {
                    sw.WriteLine(texto);
                }
            } else
            {
                using(StreamWriter sw = new StreamWriter(caminho))
                {
                    sw.WriteLine(texto);
                }
            }
        }

        public static string[] LerArquivo(string filename)
        {
            string caminho = caminhoBase + filename + ".txt";
            return File.ReadAllLines(caminho);
        }
    }
}

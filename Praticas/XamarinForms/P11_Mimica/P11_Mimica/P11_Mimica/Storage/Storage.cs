using P11_Mimica.Model;

namespace P11_Mimica.Storage
{
    public static class Storage
    {
        public static Jogo Jogo { get; set; }
        public static short RodadaAtual { get; set; }

        public static string[][] Palavras = {
            //Fáceis | 1pts
            new string[] {"Olho", "Lingua", "Chinelo", "Milho", "Nadar", "Bola"},

            //Medias | 3pts
            new string[] {"Marceneiro", "Carpinteiro", "Amarelo", "Limão", "Abelha"},

            //Dificeis | 5pts
            new string[] {"Cisterna", "Lanterna", "Batman vs Superman", "Notebook"},
        };
    }
}
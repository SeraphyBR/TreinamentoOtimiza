namespace P11_Mimica.Model
{
    //public enum TypeNivel { Aleatorio, Facil, Medio, Dificil }

    public class Jogo
    {
        public Grupo G1 { get; set; }
        public Grupo G2 { get; set; }

        public string Nivel { get; set; }
        public int NivelNum { get; set; }
        public short TempoPalavra { get; set; }
        public short Rodadas { get; set; }
    }
}
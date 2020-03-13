using SQLite;

namespace P10_Vagas.Modelos
{
    public enum TypeContratacao { PJ, CLT }

    [Table("Vaga")]
    public class Vaga
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Empresa { get; set; }
        public short Quantidade { get; set; }
        public string Cidade { get; set; }
        public double Salario { get; set; }
        public string Descricao { get; set; }
        public TypeContratacao TipoContratacao { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
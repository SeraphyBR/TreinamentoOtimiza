using System;

namespace Biblioteca.Model
{
    public abstract class Pessoa
    {
        private DateTime _dataNascimento;
        private int _cep;

        public string Nome { get; set; }
        public string DataNascimento
        {
            get
            {
                return _dataNascimento.ToString();
            }
            set
            {
                _dataNascimento = DateTime.Parse(value);
            } 
        }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Telefone { get; set; }

        public string CEP
        {
            get
            {
                return _cep.ToString();
            } 
            set
            {
                _cep = int.Parse(value);
            }
        }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }
    }
}

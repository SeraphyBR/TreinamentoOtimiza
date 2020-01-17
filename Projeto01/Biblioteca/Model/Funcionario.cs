using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Model
{
    public sealed class Funcionario : Pessoa
    {
        private DateTime _dataContratacao;
        private double _salario;
        public string Cargo { get; set; }
        public string Salario
        {
            get
            {
                return _salario.ToString();
            }
            set
            {
                _salario = double.Parse(value);
            }
        }
        public string DataContratacao
        {
            get
            {
                return _dataContratacao.ToString();
            }
            set
            {
                _dataContratacao = DateTime.Parse(value);
            }
        }

        public override string ToString()
        {
            string output = String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}",
                this.Nome,
                this.DataNascimento,
                this.Telefone,
                this.CPF,
                this.RG,
                this.CEP,
                this.Estado,
                this.Cidade,
                this.Endereco,
                this.Cargo,
                this.Salario,
                this.DataContratacao
            );
            return output;
        }

        public static Funcionario FromString(string linha)
        {
            string[] elementos = linha.Split(',');
            Funcionario f = new Funcionario()
            {
                Nome = elementos[0],
                DataNascimento = elementos[1],
                Telefone = elementos[2],
                CPF = elementos[3],
                RG = elementos[4],
                CEP = elementos[5],
                Estado = elementos[6],
                Cidade = elementos[7],
                Endereco = elementos[8],
                Cargo = elementos[9],
                Salario = elementos[10],
                DataContratacao = elementos[11]
            };
            return f;
        }

    }
}

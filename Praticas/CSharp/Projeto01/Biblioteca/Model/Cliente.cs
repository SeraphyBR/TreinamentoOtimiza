using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Model
{
    public sealed class Cliente : Pessoa
    {
        public override string ToString()
        {
            string output = String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}",
                this.Nome,
                this.DataNascimento,
                this.Telefone,
                this.CPF,
                this.RG,
                this.CEP,
                this.Estado,
                this.Cidade,
                this.Endereco
            );
            return output;
        }

        public static Cliente FromString(string linha)
        {
            string[] elementos = linha.Split(',');
            Cliente c = new Cliente()
            {
                Nome = elementos[0],
                DataNascimento = elementos[1],
                Telefone = elementos[2],
                CPF = elementos[3],
                RG = elementos[4],
                CEP = elementos[5],
                Estado = elementos[6],
                Cidade = elementos[7],
                Endereco = elementos[8]
            };
            return c;
        }
    }


}

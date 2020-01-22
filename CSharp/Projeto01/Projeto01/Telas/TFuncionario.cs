using System;
using System.Collections.Generic;
using System.Text;
using Biblioteca.Model;
using Biblioteca.Arquivo;

namespace Projeto01.Telas
{
    class TFuncionario
    {
        public void CadastrarFuncionario()
        {
            Funcionario f = new Funcionario();

            Console.Clear();

            Console.WriteLine("*** Cadastrar Funcionario ***");
            Console.Write("Nome: ");
            f.Nome = Console.ReadLine();

            Console.Write("Data de Nascimento: ");
            f.DataNascimento = Console.ReadLine();

            Console.Write("Telefone: ");
            f.Telefone = Console.ReadLine();

            Console.Write("CPF: ");
            f.CPF = Console.ReadLine();

            Console.Write("RG: ");
            f.RG = Console.ReadLine();

            Console.Write("CEP: ");
            f.CEP = Console.ReadLine();

            Console.Write("Estado: ");
            f.Estado = Console.ReadLine();

            Console.Write("Cidade: ");
            f.Cidade = Console.ReadLine();

            Console.Write("Endereço: ");
            f.Endereco = Console.ReadLine();

            Console.Write("Cargo: ");
            f.Cargo = Console.ReadLine();

            Console.Write("Salario: ");
            f.Salario = Console.ReadLine();

            Console.Write("Data de Contratação: ");
            f.DataContratacao = Console.ReadLine();

            GerenciadorArquivo.GravarArquivo("funcionario", f.ToString());
        }

        public void ListarFuncionarios()
        {
            Console.Clear();
            Console.WriteLine("*** Listagem de Funcionarios ***");

            string[] linhas = GerenciadorArquivo.LerArquivo("funcionario");

            foreach(string linha in linhas)
            {
                Funcionario f = Funcionario.FromString(linha);
                Console.WriteLine($"Nome: {f.Nome} Cargo: {f.Cargo}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Biblioteca.Model;
using Biblioteca.Arquivo;
namespace Projeto01.Telas
{
    class TCliente
    {
        public void CadastrarCliente()
        {
            Cliente cliente = new Cliente();

            Console.Clear();

            Console.WriteLine("*** Cadastrar Cliente ***");
            Console.Write("Nome: ");
            cliente.Nome = Console.ReadLine();

            Console.Write("Data de Nascimento: ");
            cliente.DataNascimento = Console.ReadLine();

            Console.Write("Telefone: ");
            cliente.Telefone = Console.ReadLine();

            Console.Write("CPF: ");
            cliente.CPF = Console.ReadLine();

            Console.Write("RG: ");
            cliente.RG = Console.ReadLine();

            Console.Write("CEP: ");
            cliente.CEP = Console.ReadLine();

            Console.Write("Estado: ");
            cliente.Estado = Console.ReadLine();

            Console.Write("Cidade: ");
            cliente.Cidade = Console.ReadLine();

            Console.Write("Endereço: ");
            cliente.Endereco = Console.ReadLine();

            GerenciadorArquivo.GravarArquivo("cliente", cliente.ToString());


        }

        public void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("*** Listagem de Clientes ***");

            string[] linhas = GerenciadorArquivo.LerArquivo("cliente");

            foreach(string linha in linhas)
            {
                Cliente c = Cliente.FromString(linha);
                Console.WriteLine($"Nome: {c.Nome}");
            }
        }
    }
}

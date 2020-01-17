using System;
using Projeto01.Telas;

namespace Projeto01
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 0;
            while(input != 5)
            {
                Console.Write(
                    "O que deseja fazer?\n" +
                    "1 - Cadastrar Cliente\n" +
                    "2 - Listar Clientes\n" +
                    "3 - Cadastrar Funcionario\n" +
                    "4 - Listar Funcionarios\n" +
                    "5 - Fechar Programa\n" +
                    "=> "
                );

                input = int.Parse(Console.ReadLine());
                TCliente telaCliente = new TCliente();
                TFuncionario telaFuncionaro = new TFuncionario();
                switch (input)
                {
                    case 1:
                        telaCliente.CadastrarCliente();
                        break;
                    case 2:
                        telaCliente.ListarClientes();
                        break;
                    case 3:
                        telaFuncionaro.CadastrarFuncionario();
                        break;
                    case 4:
                        telaFuncionaro.ListarFuncionarios();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Comando não encontrado!");
                        break;
                 
                }

            }
        }
    }
}

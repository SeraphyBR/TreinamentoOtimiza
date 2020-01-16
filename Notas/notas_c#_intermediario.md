# Nota das aulas do curso Intermediario de C# - Otimiza

-   Obs: Assembly em C# significa o Nome do Projeto

## Auto-Implement Propriety

Criação automatica de "metodos" Get e Set para acesso dos atributos de uma classe

```csharp
    class Pessoa {
        private string _nome;

        // Padrão automatico
        public string Nome { get; set; }

        // Customizado
        public string Name {
            get {
                return _nome.ToLower();
            }
            set {
                // value é o valor recebido da entrada
                // p.Name = value;
                _nome = value.Trim();
            }
        }; // Customizado
    }
```

## ReadyOnly (Constantes?)

```csharp
    class Pessoa {
        public readonly double PI = 3.14;

        public readonly string Nome = "Elias Costa";

        Pessoa() {
            Nome = "João";
        }

        public void SetNome(string nome) {
            Nome = nome; // Erro não é possivel fazer essa atribuição.
        }
    }
```

## Struct vs Class

-   Voce não pode inicializar o atributo de uma struct com um valor default fora do construtor.
-   Não pode ter metodo construtor sem parametros.
-   É criado usando new, assim como as classes.
-   A Struct é salva por valor e não por referencia como as classes.

## Passagem por referencia

```csharp
    class Program {
        static void Main() {
            double valor = 25;
            AlterarValor(ref valor);
            Console.ReadyKey();
        }

        static void AlterarValor(ref double valor) {
            valor += 10;
        }
    }
```

## Palavra chave 'out'

-   tipo de passagem por referencia, mas sem leitura, só escrita permitida.

```csharp
    class Program {
        static void Main(string[] args) {
            double valor = 25;

            AlterarValor(out valor);

            int idade;
            string nome = RetornarNomeIdadePessoa(new DateTime(10,10,2000), out idade);

            Console.ReadKey();
        }

        static void AlterarValor(out double valor) {
            valor = valor + 10; // Erro
            valor = 10;
        }

        // O out é tambem usado quando se precisa retornar mais de um valor.
        // exemplo de metodo que o utiliza: bool int.TryParse(string s, out int result);
        static string RetornarNomeIdadePessoa(DateTime dataNascimento, out int idade) {
            idade = 10;
            return "Nome";
        }
    }
```

## Palavra chave 'params' (Parametros infinitos)

```csharp
    class Program {
        static void Main(string[] args) {
            VariasEntradas(10, "Elias", "José", "Maria", "Filipe", "Jesus");
        }

        // Obrigatoriamente o parametro com o params deve ser o ultimo na declaração do metodo
        static void VariasEntradas(int idade, params string[] nomes) {

        }
    }
```

## Classes Parciais

-   Permite dividir uma classe em varios arquivos, podendo dividir, por exemplo, em atributos e metodos.

```csharp
    // Carro.param.cs
    partial class Carro {
        int NumRodas;
        string Modelo;
        string Marca
        DateTime AnoFabricacao;
        DateTime AnoModelo;
    }

    // Carro.metod.cs
    partial class Carro {
        void LigarFarol();
        void LigarArCondicionado();
        //...
    }
```

## Metodos Parciais

-   Metodos que podem divir sua assinatura da sua implementação
-   Não podem ter modificadores de acesso, são sempre privados.
-   Não podem retornar informações, sempre void.
-   Caso o metodo parcial não seja implementado, ele sera desconsiderado.

```csharp
    // arquivo1.cs
    partial class Carro {
        partial void FacaAlgo(string andar);
    }

    // arquivo2.cs
    partial class Carro {
        partial void FacaAlgo(string andar) {
            //implementacao
        }
    }
```

## Classe abstrada

-   Não podem ser instanciadas, apenas herdadas.
-   Tipo de restrição.
-   Servem apenas como modelo.

```csharp
    // arquivo1.cs
    abstract class Veiculo {
        string Modelo;
        string AnoModeloFabricacao;
        byte Eixos;
        byte Rodas;

        // Propriedade Auto-implement abstrata
        abstract public string Marca { get; set; };

        // Método abstrato
        public void MudarMarcha(byte NumeroMarcha){}
    }

    // arquivo2.cs
    class Carro : Veiculo {
        public override void MudarMarcha(byte NumeroMarcha){
            // Implementacao
        }

        // Como foi declarado ela com get e set, voce é obrigado
        // a implementá-los
        public override string Marca {
            get {
                // implementacao
            }
            set {
                // implementacao
            }
        }
    }
```

## Classe Sealed

-   Não podem ser herdadas.
-   Por padrão as structs sempre são sealed.

```csharp
    sealed class Veiculo {
        // algo
    }

    class Carro : Veiculo { // Erro

    }
```

## Interfaces

-   Toda interface começa com a letra I maiuscula.
-   Não contem nenhuma implementacao.
-   Semelhantes a classes e metodos abstratos.
-   Uma classe pode herdar apenas de uma outra classe, mas pode implementar varias Interfaces.
-   Diferente de uma Herança comum, quando se implementa uma interface, o mesmo deve implementar todos os metodo ou propriedades do mesmo.

```csharp
    // ITransporte.cs
    interface ITransporte {
        void Mover(byte velocidade);
    }

    // Carro.cs
    class Carro : Veiculo, ITransporte {
        public void Mover(byte velocidade) {
            //Implementação
        }
    }
```

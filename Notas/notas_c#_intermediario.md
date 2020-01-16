# Nota das aulas do curso Intermediario de C# - Otimiza

* Obs: Assembly em C# significa o Nome do Projeto

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

* Voce não pode inicializar o atributo de uma struct com um valor default fora do construtor.
* Não pode ter metodo construtor sem parametros.
* É criado usando new, assim como as classes.
* A Struct é salva por valor e não por referencia como as classes.
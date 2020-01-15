# Nota das aulas do curso Basico de C# - Otimiza

## Herança

``` csharp
    class filho : pai {

    }
```

## For each

``` csharp
    foreach(livro in estante) {

    }
```

## Sobrescrita

Para se sobrescrever um metodo da classe Pai basta implementar ela na classe
filho, não é obrigatório uso de palavra chave como a @Override em java, que fica
acima da declaração. Contudo em csharp, de forma há deixar explicito que está
ocorrendo uma sobrescrita de um método, escreve-se override antes do nome do
metodo.


### Sobrescrita de metodo da classe Pai no Filho, e chamada da implementação da
### classe pai

``` csharp
    class Moto : Veiculo {
        public override void Mover(){
            Console.WriteLine("Mover chamado dentro de: Moto.Mover");
            base.Mover();//Implementação do Mover da classe pai
        }
    }
```
# Nota das aulas do curso Basico de C# - Otimiza

## Herança

```csharp
class filho : pai {

}
```

## For each

```csharp
foreach(Tipo livro in estante) {

}
```

## Sobrescrita

Para se sobrescrever um metodo da classe Pai basta implementar ela na classe
filho, não é obrigatório uso de palavra chave como a @Override em java, que fica
acima da declaração. Contudo em csharp, de forma há deixar explicito que está
ocorrendo uma sobrescrita de um método, escreve-se override antes do nome do
metodo.

```csharp
class Moto : Veiculo {
    public override void Mover(){
        Console.WriteLine("Mover chamado dentro de: Moto.Mover");
        base.Mover();//Implementação do Mover da classe pai
    }
}
```

-   Sobrescrita de metodo da classe Pai no Filho, e chamada da implementação da classe Pai

## Comentario de Documentação

```csharp
/// <summary>
/// Está classe é responsável por gerenciar todos os comportamentos genéricos de um veículo
/// </summary>
class Veiculo
{
    /// <summary>
    /// Marca do veículo
    /// </summary>
    public string Marca;

    /// <summary>
    /// Método responsável por mover o veículo
    /// </summary>
    /// <param name="medida"> 0 - para Metros e 1 - para Kilometros </param>
    public void Mover(int medida)
    {

    }
}
```

## Operadores Lógicos

-   &, | -> irá executar os dois lados mesmo se a primeira ja for falsa.
-   &&, || -> irá executar o primeiro lado e se ela for falsa não realiza a segunda.

## Formatando string

```csharp
string nome = "Luiz Junio";
string nome2 = "SeraphyBR";
string texto = String.Format("Bem vindo {0}! Feliz Natal! {1}", nome, nome2);
```

### Split

```csharp
string nomes = "João, Maria, José, Jesus e Paulo.";
string[] separador = { ", ", " e "};
string[] nomesArray1 = nomes.Split(",");
string[] nomesArray2 = nomes.Split(separador, StringSplitOptions.None);
```

### Substring

```csharp
string texto = "Olá a todos! Desejo feliz ano novo!";

int indexDesejo = texto.IndexOf("Desejo");
string frase = texto.Substring(indexDesejo);
string palavra = texto.Substring(indexDesejo, 6);
```

## Visual Studio

-   F1 -> Abre a documentação sobre o codigo selecionado.
-   F12 -> Abre a implementação de um metodo ou classe.

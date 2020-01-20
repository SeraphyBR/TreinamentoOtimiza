# Nota das aulas do curso Avançado de C# - Otimiza

## Serialização XML

-   using System.Xml.Serialization;
-   using System.IO;

```csharp
    Usuario usuario = new Usuario(){
        Nome = "Luiz Junio",
        CPF = "127.0.0.1",
        Email = "luisjuniorbr@gmail.com"
    };

    XmlSerializer serializador = new XmlSerializer(typeof(Usuario));

    // o @ na frente diz para tratar como uma string literal
    StreamWriter sw = new StreamWriter(@"C:\Users\luiz.santos\Documents\usuario.xml");

    //Escreve o arquivo xml
    serializador.Serialize(sw, usuario);
```

## Deserialização Xml

-   using System.Xml.Serialization;
-   using System.IO;

```csharp
    // o @ na frente diz para tratar como uma string literal
    StreamReader sr = new StreamReader(@"C:\Users\luiz.santos\Documents\usuario.xml");

    XmlSerializer serializador = new XmlSerializer(typeof(Usuario));

    // Lê o arquivo xml para um object
    Usuario usuario = (Usuario) serializador.Deserialize(sr);
```

## Serialização JSON

-   é necessario adicionar uma referencia ao pacote System.Web.Extensions em Framework
-   using System.Web.Script.Serialization;
-   using System.IO;

```csharp
    Usuario usuario = new Usuario(){
        Nome = "Luiz Junio",
        CPF = "127.0.0.1",
        Email = "luisjuniorbr@gmail.com"
    };

    JavaScriptSerializer serializador = new JavaScriptSerializer();
    string objSerializado = serializador.Serialize(usuario);

    // o @ na frente diz para tratar como uma string literal
    StreamWriter sw = new StreamWriter(@"C:\Users\luiz.santos\Documents\usuario.json");

    // Escreve o json no arquivo
    sw.WriteLine(objSerializado);
    sw.Close();
```

## Deserialização JSON

-   é necessario adicionar uma referencia ao pacote System.Web.Extensions em Framework
-   using System.Web.Script.Serialization;
-   using System.IO;

```csharp
    // o @ na frente diz para tratar como uma string literal
    StreamReader sr = new StreamReader(@"C:\Users\luiz.santos\Documents\usuario.json");
    string linhasDoArquivo = sr.ReadToEnd();

    JavaScriptSerializer serializador = new JavaScriptSerializer();
    Usuario usuario = (Usuario) serializador.Deserialize(linhasDoArquivo, typeof(Usuario));

    Console.WriteLine($"Usuario: {usuario.Nome}");
```

## Generics

```csharp
    // Serializador "Generico" usando object
    public static void Serializar(object obj){
        StreamWriter sw = new StreamWriter(
            @"C:\Users\luiz.santos\Documents\" + obj.GetType().Name + ".txt"
        );

        JavaScriptSerializer serializador = new JavaScriptSerializer();
        string objSerializado = serializador.Serializer();

        sw.Write(objSerializado);
        sw.Close();
    }

    // Usando sintaxe de Generics
    public static T Deserializar<T>(){
        StreamReader sr = new StreamReader(
            //Obtem se o nome do tipo usando typeof(T).Name
            @"C:\Users\luiz.santos\Documents\" + typeof(T).Name + ".txt"
        );
        string conteudo = sr.ReadToEnd();

        JavaScriptSerializer serializador = new JavaScriptSerializer();
        T obj = (T) serializador.Deserialize(conteudo, typeof(T));

        return obj;
    }
```

## Palavras chaves Var e Dynamic

### Var

-   Usado para não ter que escrever o nome do Tipo.
-   Assim que recebe um valor, não se pode atribuir um valor de tipo diferente.
-   Voce é obrigado a atribuir um valor a variavel na sua declaração.

### Dynamic

-   Funciona em tempo de execução, e não durante a compilação.
-   Não apresenta nenhum erro de compilação, somente de execução.
-   Não é obrigado a atribuir um valor na sua declaração.
-   Pode se atribuir um valor de tipo diferente do atual.

## Extension Methods

-   Permite extender uma classe, mesmo ela sendo sealed.
-   Adiciona metodos a uma classe, sem estar na declaração da mesma.
-   Na declaração de uma "classe" de extensão, a mesma deve ser estática.
-   O metodo a ser adicionado deve ser declarado como estático.
-   Voce pode deixar a classe criada com o proposito de extensão com o namespace System, assim não é preciso importar.
-   Similar a sintaxe de metodos em rust, mas diferente do self como primeiro parametro, é usado this Tipo, indicando o tipo da classe a ser extendida.

```csharp
    class Program {
        static void Main(string[] args) {
            string valor = "olá mundo!";
            // Uso do metodo extendido
            Console.WriteLine(valor.FirstToUpper());
            Console.ReadKey();
        }
    }

    public static class StringExtension {
        public static string FirstToUpper(this string str) {
            string Primeira = str.Substring(0, 1).ToUpper();
            string Segunda = str.Substring(1);
            return Primeira + Segunda;
        }
    }
```

## Nullable

-   Util quando a fonte de informações pode contem valores nulos.
-   Permite que um tipo primitivo como int, que é uma struct, possa receber um valor nulo.
-   Util quando importar dados de um banco de dados como MySQL, Oracle, NoSQL. Que podem possuir campos de dados opcionais.

```csharp
    // Erro
    int i = null;

    // Duas sintaxes para o nullable
    Nullable<int> Idade = null;
    int? Idade = null;
```

## LINQ

-   Sub-linguagem para manipulação de dados, como em listas, arrays e etc.
-   Representação da linguagem SQL em C#.
-   Uso de LAMBDA.
-   Diferente do SQL, o Select é a ultima expressão no LINQ.

```csharp
    //LINQ e LAMBDA
    //LAMBDA = (entrada) => (expressao)
    int[] lista = {3,9,4,6,20,10,60,90,80,50};

    // .Where() vai filtrar a lista
    // .OrderBy() vai ordernar a lista com base no tipo da entrada
    // .Select() vai retornar os valores da lista
    var listaFiltrada = lista.Where(x => x > 10).OrderBy(x => x).Select(x => x);

    // Segunda sintaxa do LINQ, sem uso de chamada de Metodo ou LAMBDA.
    // Mais parecido com SQL
    var listaFiltrada = from a in lista where a > 10 orderby a select a;

    foreach(var item in listaFiltrada){
        Console.WriteLine(item);
    }

    Console.ReadKey();
```

### Com objetos

```csharp
    List<Usuario> lista = new List<Usuario>();
    lista.Add(new Usuario() { Nome = "José", Email = "jose@gmail.com" });
    lista.Add(new Usuario() { Nome = "Maria", Email = "maria@hotmail.com" });
    lista.Add(new Usuario() { Nome = "João", Email = "joao@ig.com" });
    lista.Add(new Usuario() { Nome = "Felipe", Email = "felipe@gmail.com" });
    lista.Add(new Usuario() { Nome = "Elias", Email = "elias@gmail.com" });

    var listaFiltrada = lista.Where(u => u.Email.Contains("@gmail.com")).OrderBy(u => u.Nome).Select(u => u);

    foreach(var user in listaFiltrada){
        Console.WriteLine(user.Nome + " - " + user.Email);
    }
    Console.ReadKey();
```

### Usando Join

```csharp
    List<Livro> listaLivros = new List<Livro>();
    listaLivros.Add(new Livro() { Id = 1, AutorId = 2, Titulo = "Amor amado" });
    listaLivros.Add(new Livro() { Id = 2, AutorId = 2, Titulo = "Bem amado" });
    listaLivros.Add(new Livro() { Id = 3, AutorId = 3, Titulo = "Um espião em DC" });
    listaLivros.Add(new Livro() { Id = 4, AutorId = 1, Titulo = "A vida na terra" });

    List<Autor> listaAutores = new List<Autor>();
    listaAutores.Add(new Autor() { Id = 1, Nome = "Leonardo" });
    listaAutores.Add(new Autor() { Id = 2, Nome = "Maria Maria" });
    listaAutores.Add(new Autor() { Id = 3, Nome = "Joseph" });

    var listaJoin = from livro in listaLivros
                    join autor in listaAutores
                    on livro.AutorId equals autor.Id
                    select new { livro, autor };//Criacao de um tipo anonimo, sem nome.

    foreach (var item in listaJoin) {
        Console.WriteLine("Livro: " + item.livro.Titulo + " - Autor: " + item.autor.Nome);
    }
    Console.ReadKey();
```

### GroupBy e Distinct

```csharp
    int[] listaNums = {1,1,1,1,4,4,2,3,5,6,6,10,9,8};

    //Mesmo resultado, irá mostrar sem repetição de valores
    var listaFiltrada = listaNums.Distinct().OrderBy(a => a).Select(a => a);
    var listaFiltrada = listaNums.OrderBy(a => a).GroupBy(a => a).Select(a => a);

    foreach(var num in listaFiltrada){
        //Usando o distinct
        Console.WriteLine(num);

        //Usando o GroupBy
        Console.WriteLine(num.Key);
    }
    Console.ReadKey();
```

## Delegate

-   Um tipo de ponteiro para Metodos.
-   Voce pode associar metodos para um delegate, que quando chamado irá executar todos.
-   Voce pode desvincular metodos de um delegate.
-   Usado comumente com Eventos.
-   Permite executar um metodo mesmo sem saber qual.
-   Usado para se passar metodos como parametro para outros metodos.
-   Muito utilizado a palavra Handler para designar um Delegate.
-   Os metodos associados devem possue os mesmos tipos de retorno e parametros do delegate.

```csharp
    class Program {
        static void Main(string[] args) {
            //Tela - Cadastro de Usuario: Thumb (Foto de Perfil)
            Foto foto = new Foto {Nome = "perfil.jpg", TamanhoX = 1920, TamanhoY = 1080};
            //Atribuindo o metodo GerarThumb ao delegate filtros
            FotoProcessador.filtros = new FotoFiltro().GerarThumb;
            //Executa os metodos do delegate, passando a foto como parametro.
            FotoProcessador.Processar(foto);

            //Tela - Cadastro de Produtos: Colorir + TamanhoMed
            Foto foto2 = new Foto {Nome = "produto.jpg", TamanhoX = 1920, TamanhoY = 1080};
            FotoProcessador.filtros = new FotoFiltro().Colorir;
            FotoProcessador.filtros += new FotoFiltro().RedimensionarTamMedio;
            FotoProcessador.Processar(foto2);

            //Tela - Cadastro de Albuns do Usuario - Retro: Preto e Branco
            Foto foto3 = new Foto {Nome = "album.jpg", TamanhoX = 1920, TamanhoY = 1080};
            FotoProcessador.filtros = new FotoFiltro().PretoBranco;
            FotoProcessador.Processar(foto3);
        }
    }

    class Foto {
        public string Nome  { get; set; }
        public int TamanhoX { get; set; }
        public int TamanhoY { get; set; }
    }

    class FotoProcessador {
        //Criação de um novo Delegate
        public delegate void FotoFiltroHandler(Foto foto);

        //Declaração da variavel filtros do tipo do Delegate
        public static FotoFiltroHandler filtros;

        public static void Processar(Foto foto){
            filtros(foto);
        }
    }

    public class FotoFiltro {
        public void Colorir(Foto foto){
            Console.WriteLine($"FotoFiltro > Colorir: {foto.Nome}");
        }
        public void GerarThumb(Foto foto){
            Console.WriteLine($"FotoFiltro > GerarThumb: {foto.Nome}");
        }
        public void PretoBranco(Foto foto){
            Console.WriteLine($"FotoFiltro > PretoBranco: {foto.Nome}");
        }
        public void RedimensionarTamMedio(Foto foto){
            Console.WriteLine($"FotoFiltro > RedimensionarTamMedio: {foto.Nome}");
        }
    }
```

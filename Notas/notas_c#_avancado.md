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

## Threads

-   using System.Threading;

```csharp
class Program {
    static int Rede = 0;
    static object variavelDeControle = 0;

    static void Main(string[] args) {
        Console.WriteLine($"DataIni: {DateTime.Now}");

        //Cria 5 threads (6 rodando, pois tem a thread principal da Main)
        for(int i = 0; i < 5; i++){

            //Instancia uma nova thread passando um metodo como parametro.
            Thread t1 = new Thread(ThreadRepeticao);

            //Quando essa propriedade fica com true, faz com que as
            //Threads criadas fiquem dependente da thread principal,
            //Logo elas são encerradas quando o programa principal chegar ao fim.
            t1.IsBackground = true;

            //Inicia a thread e passa i como parametro ao metodo ThreadRepeticao
            t1.Start(i);
        }

        Thread t2 = new Thread(ThreadRepeticao);
        t2.Start();
        // O join fara com que a thread t2 se junte a thread principal
        // Fazendo com que a thread principal espere a t2 acabar para poder
        // prosseguir e mostrar a mensagem.
        t2.Join();
        Console.WriteLine("Vc passou por aqui!");

        Console.ReadKey();
    }

    static void ThreadRepeticao(object Id){
        for(int i = 0; i < 1000; i++){
            // Lock irá bloquear os recursos dentro dele, impedindo que outras threads acessem
            // durante o seu uso, isso irá fazer com que as threads acabem proximas uma das outras,
            // nesse caso. o lock opera em FIFO.
            lock(variavelDeControle){
                Console.WriteLine($"Thread: {Id} - Num: {i} ID Interno: {Thread.CurrentThread.ManagedThreadId}");
                Rede++;
            }
        }
        Console.WriteLine($"DataIni: {DateTime.Now}");
    }
}
```

### AutoResetEvent e ManualResetEvent

-   Funcionam como semaforos que interrompem ou liberam a execução de uma thread
-   Servem de controle para as threads

```csharp
static ManualResetEvent manual01;
static AutoResetEvent auto01;

static void Main(string[] args){
    //Instancia com estado inicial de bloqueio
    manual01 = new ManualResetEvent(false);
    auto01 = new AutoResetEvent(false);

    Thread t1 = new Thread(Executa01);
    t1.Start();

    Thread t2 = new Thread(Executa02);
    t2.Start();

    Thread.Sleep(5000);
    manual01.Set();//Libera a execução das threads que estão esperando
    manual01.Reset();//Bloqueia a execução

    //Libera a execução das threads que estão esperando, e logo em seguida bloqueia.
    auto01.Set();

    Console.ReadKey();
}

static void Executa01(){
    Console.WriteLine("01 - Iniciado Executa01.");
    //Faz com que a thread espere a liberação vinda do manual01
    manual01.WaitOne();
    Console.WriteLine("02 - Em execução 01 Executa01.");
    Console.WriteLine("03 - Em execução 02 Executa01.");
    //Faz com que a thread espere a liberação vinda do manual01
    manual01.WaitOne();
    Console.WriteLine("04 - Finalizado Executa01.");
}

static void Executa02(){
    Console.WriteLine("01 - Iniciado Executa02.");
    //Faz com que a thread espere a liberação vinda do auto01
    auto01.WaitOne();
    Console.WriteLine("02 - Em execução 01 Executa02.");
    Console.WriteLine("03 - Em execução 02 Executa02.");
    Console.WriteLine("04 - Finalizado Executa01.");
}
```

## Task

-   Utilizam threads em sua implementação
-   Melhoramento da classe Thread
-   using System.Threading.Tasks;

```csharp
static void Main(string[] args) {
    //Criando tasks usando o metodo Run passando uma função lambda
    Task.Run(() => Metodo01());
    Task.Run(() => Metodo01());

    //Criando tasks sem lambda
    Task.Factory.StartNew(Metodo01);

    List<Task> lista = new List<Task>();
    lista.Add(Task.Factory.StartNew(Metodo01));
    lista.Add(Task.Factory.StartNew(Metodo01));
    lista.Add(Task.Factory.StartNew(Metodo01));
    lista.Add(Task.Factory.StartNew(Metodo01));

    //Irá fazer com que a thread principal espere
    //todas as tasks finalizarem
    Task.WaitAll(lista.ToArray());

    //Irá fazer com que a thread principal espere
    //ao menos uma task finalizar
    Task.WaitAny(lista.ToArray());

    Console.WriteLine("Programa finalizado!!!");
    Console.ReadKey();
}

static void Metodo01(){
    for(int i = 0; i < 1000; i++){
        Console.WriteLine($"Valor: {i} TaskID: {Task.CurrentId}");
    }
}
```

## Atributos

-   Servem para dizer uma informação sobre uma classe,metodo,propriedade e etc.
-   Podem ser utilizadas para validação de propriedades.
-   Em classes derivadas de Attribute é comum colocar o suffixo Attribute no nome.

```csharp
[MeuAtributo("Atributo Classe", Descricao = "Descrição do Atributo")]
class Program {

}

//Definindo em que tipos de dados o atributo pode ser utilizado
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method)]
class MeuAtributo : Attribute {
    //Criação do seu proprio atributo
    public string Nome { get; set; }
    public string Descrição { get; set; }

    public MeuAtributo(string nome){
        Nome = nome;
    }
}
```

### Validação com Data Annotation

-   ValidationAttribute
-   using System.ComponentModel.DataAnnotations;

```csharp
class Program {
    static void Main(string[] args) {
        Usuario usuario = new Usuario() {Nome = "José", Email = "jose", Senha = "123456" };

        ValidationContext contexto = new ValidationContext(usuario);
        List<ValidationResult> resultados = new List<ValidationResult>();

        //O validator irá validar todos os campos do objeto usuario.
        //O parametro true serve para dizer que é para verificar todas as propriedades
        if(Validator.TryValidateObject(usuario, contexto, resultados, true) == false) {
            //Mensagens
            foreach(var erro in resultados){
                Console.WriteLine(erro.ErrorMessage);
            }
        }
        Console.ReadKey();
    }
}

class Usuario {
    //Adicionando o atributo required e setando a mensagem de erro
    [Required(ErrorMessage = "O campo 'Nome' é de preenchimento obrigatório!")]
    public string Nome  { get; set; }

    // Usando um arquivo de Resources (.resx) para obter a mensagem de erro
    // Isso permite definir mensagems personalizadas de acordo com o idioma
    // Ex: Linguagem.resx, Linguagem.pt.resx, Linguagem.pt-BR.resx ...
    [Required(ErrorMessageResourceType = typeof(Idiomas.Linguagem), ErrorMessageResourceName = "MSG_OBRIGATORIO")]
    [EmailAddress]//Atributo que valida se a propriedade possue um endereço de email valido
    public string Email { get; set; }

    // Observe que o construtor de StringLenght recebe somente
    // O valor máximo (primeiro parametro), mas voce pode atribuir valores a demais campos
    // com Propriedade = valor
    [Required, StringLength(10, MinimumLenght = 6)]
    [MyValidacao]
    public string Senha { get; set; }
}

//Criação de um atributo de validação customizado
class MyValidacaoAttribute : ValidationAttribute {
    public override bool IsValid(object value){
        if(((string) value).Lenght == 10){
            return true;
        }
        else {
            return false;
        }
    }
}
```

## Reflections

-   Estrutura da linguagem c# (Não é um tipo ou palavra-chave)
-   Permite identificar os campos de um objeto
-   A serialização de objeto utiliza Reflections
-   Uso da classe Type

```csharp
class Program {
    static void Main(string[] args) {
        Usuario usuario = new Usuario(){
            Nome = "José",
            Email = "jose",
            Senha = "12345ab"
        };
        Log.Gravar(usuario.Clone());

        usuario.Nome = "José Costa";
        Log.Gravar(usuario.Clone());

        Carro carro = new Carro(){
            Marca = "FIAT",
            Modelo = "UNO"
        }
        Log.Gravar(carro);

        Log.ApresentarLog();

        Console.WriteLine("Log Gravado !");
        Console.ReadKey();
    }
}

class Log {
    public static List<object> objetos = new List<object>();

    public static void Gravar(object obj){
        objetos.Add(obj);
    }

    public static void ApresentarLog(){
        foreach(object obj in objetos){
            Console.WriteLine("----- Nome classe: {0} -----", obj.GetType().Name);
            foreach(var prop in obj.GetType().GetProperties()){
                Console.WriteLine($"{prop.Name} : {prop.GetValue(obj)}");
            }
        }
    }
}

class Usuario : ICloneable {
    public string Nome  { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }

    public object Clone(){
        return new Usuario() { Nome = this.Nome, Email = this.Email, Senha = this.Senha }
    }
}
```

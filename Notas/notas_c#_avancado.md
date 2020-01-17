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

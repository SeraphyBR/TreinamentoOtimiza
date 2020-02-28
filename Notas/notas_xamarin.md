# Nota das aulas do curso De Xamarin Forms - Otimiza

-   Curso da Udemy de referencia: https://www.udemy.com/course/xamarin-forms-2018-apps-para-android-ios-e-uwp-8-apps
-   Documentação Oficial: https://docs.microsoft.com/pt-br/xamarin/

### Xamarin vs Xamarin Forms

-   Com o Xamarin você faz códigos específicos para cada plataforma, apenas o backend C# é compartilhado.
-   Com o Xamarin Forms, voce usa o mesmo código de frontend para as 3 plataformas suportadas, podendo fazer pequenas partes especificas para cada um, o backend tambem é compartilhado.

### Formas disponíveis de compartilhamento de código entre os 3 sistemas operacionais

-   Shared

    -   Possui um projeto a parte, do tipo Shared.
    -   Pode conter todas as regras de negócio, classes, arquivos.
    -   Quando ocorre a compilação, o projeto será compilado junto do projeto especifico do sistema operacional, como se todas as classes estivessem no projeto especifico.
    -   Vantagem:
        -   Permite o projeto shared ter acesso direto as APIs dos projetos específicos e vice-versa.
    -   Desvantagem:

        -   Como um único código vai ser disponibilizado para as 3 plataformas, deve-se preocupar em isolar as partes especificas de cada um, senão, por exemplo, quando uma aplicação IOS rodar, pode acabar chamando uma API do Android.
        -   Uso de diretivas de compilação:
        -   ```CSharp
            #if __ANDROID__
                // código que roda só no android
            #endif

            #if __IOS__
                // código que roda só no ios
            #endif
            ```

        -   [Documentação](https://docs.microsoft.com/pt-br/xamarin/cross-platform/app-fundamentals/building-cross-platform-applications/platform-divergence-abstraction-divergent-implementation)

-   .NET Standard (Substituiu o PCL)
    -   Na compilação o projeto Shared será compilado separadamente dos projetos específicos de cada plataforma e será gerado uma DLL que então poderá ser referenciada nos projetos específicos para que possa ser feito o uso das classes e métodos do projeto Shared.
    -   Para o projeto shared (DLL) ter acesso as APIs de cada plataforma será necessário fazer injeção de dependecia, logo seu acesso não é direto, é uma conversa unilateral.

## Xamarin .NET Standart

```CSharp
// Arquivo App.xaml.cs
namespace P01_ConsultarCEP
{
    public partial class App : Application
    {
        public App(){
            // Irá carregar os dados no App.xaml
            InitializeComponent();

            // Define a primeira pagina do aplicativo
            // Cada pagina possui um xaml e cs.
            // MainPage.xaml e MainPage.xaml.cs
            MainPage = new P01_ConsultarCEP.MainPage();
        }
    }
}
```

### Construção de paginas
- Existem 3 grupos de elementos visuais para construção de paginas:
  - Pages: Onde ficam os tipos de tela.
  - Layouts: Servem para organizar os elementos na tela.
  - Views: São os controles que vão interagir com o usuário.

#### ContentPage
- É um tipo de Page.
- Um dos tipos mais utilizados.
- Só pode conter um Elemento para visualização.
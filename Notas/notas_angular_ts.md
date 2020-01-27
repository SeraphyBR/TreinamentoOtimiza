# Nota das aulas do curso De Angular (4,5,6) - Otimiza

-   Curso da Udemy de referencia: https://www.udemy.com/course/angular-pt
-   Documentação oficial: https://www.typescriptlang.org/docs/home.html

## Typescript

-   O uso de ; é opcional

### Declaração de variaveis

```typescript
let message: string = "Help me, Obi-Wan!!!";
let episode: number = 4;
//Observe que como não foi dito o tipo da variavel ele será do tipo 'any'
//O que não é o ideal de usar muitas vezes, uma vez que a ideia do
//typescript é ser um javascript tipado
let favoriteDroid = "BB-8";
```

### Funções

-   São um tipo de dados.
-   Podem possuir nome ou serem anonimas.
-   Tanto o parametro, quanto o retorno podem ser tipados.
-   Podem ser atribudas a variaveis.

```typescript
function useTheForce(name: string): void {
    console.log("Use the force: " + name);
}

let shortestRun = function(parsecs: number): boolean {
    return parsecs < 12;
};
```

#### Arrow functions

-   (parametro: tipo,...) => implementacao;
-   Permite escrever uma função ser utilizar a palavra chave function e return

```typescript
let tieFighters = ships.filter(function(ship) {
    return ship.type === "TieFighter";
});

// Arrow function correspondente
let ties = ships.filter(ship => ship.type === "TieFighter");
```

#### Dizendo que a variavel sera uma função

```typescript
let call: (name: string) => void;
// Passando uma arrow function a variavel
call = name => console.log("Do you copy, " + name + "?");

call("R2");
//> Do you copy, R2?
```

#### Parametros opcionais (função)

-   Em javascript todos os parametros são opcionais, em typescript voce é obrigado a informar-los por padrão
-   Para um parametro ser opcional, adicione o suffixo '?'

```typescript
function inc(speed: number, inc?: number): number {
    //Recebe um valor alternativo caso o parametro não seja informado
    let i = inc || 1;
    return speed + i;
}

inc(5, 1);
//> 6

//Informando um valor default logo na declaração.
//Tambem pode ser feito uma chamada de uma outra função
//no lugar do numero, que seja responsavel por definir um valor
function inc(speed: number, inc: number = 1): number {
    let i = inc;
    return speed + i;
}

inc(5, 1);
//> 6
```

#### Parametros REST

-   Permite passar inumeros valores como parametro, sem ter que literalmente criar um array na chamada
-   Chamada mais simples da função
-   préfixo ... antes do nome do parametro do tipo array

```typescript
function countJedis(jedis: number[]): number {
    return jedis.reduce((a, b) => a + b, 0);
}

countJedis([2, 3, 4]);
//> 9

function countJedis(...jedis: number[]): number {
    return jedis.reduce((a, b) => a + b, 0);
}

countJedis(2, 3, 4);
//> 9
```

### Template String

-   Começa e termina com `

```typescript
let isEnoughToBeatMF = function(parsecs: number): boolean {
    return parsecs < 12;
};

let distance = 14;
//Template script e operador ternario
console.log(
    `Is ${distance} parsecs enough to beat Millennium Falcon? ${
        isEnoughToBeatMF(distance) ? "Yes" : "No"
    }`
);
```

### Classes

```typescript
//Forma normal
class Spacecraft {
    propulsor: string;

    constructor(propulsor: string) {
        // É obrigatorio o uso do this para se referenciar
        // a uma propriedade ou metodo da classe
        this.propulsor = propulsor;
    }

    //Para definir um metodo não se utiliza da palavra chave function
    jumpIntoHyperspace() {
        console.log("Entering hyperspace with " + this.propulsor);
    }
}

//Forma reduzida
class Spacecraft {
    //A propriedade é definida no proprio construtor, como public
    constructor(public propulsor: string) {}
}

let falcon = new Spacecraft("Hyperdrive");
```

### Herança

```typescript
class MillenniumFalcon extends Spacecraft {
    constructor() {
        super("hyperdrive");
    }

    //Sobrescrita do metodo da classe Spacecraft
    jumpIntoHyperspace() {
        if (Math.random() >= 0.5) {
            //Chamada do metodo da classe pai/super
            super.jumpIntoHyperspace();
        } else {
            console.log("Failed");
        }
    }
}
```

### Interface

```typescript
interface Containership {
    cargoContainers: number;
}

//Interface pode tambem ser extendida de outras interfaces
interface Smugglership extends Containership {
    hiddenContainers: number;
    //Propriedade opcional
    extraHiddenContainers?: number;
}

class MillenniumFalcon extends Spacecraft implements Containership {
    cargoContainers: number;

    constructor() {
        super("Hyperdrive");
        this.cargoContainers = 4;
    }
}

// Uma função que recebe como parametro qualquer tipo que implementa a interface
function goodForTheJob(ship: Containership): boolean {
    return ship.cargoContainers > 2;
}

let falcon = new MillenniumFalcon();
console.log(goodForTheJob(falcon));
//> true
```

### Import e export - Divisão do programa em modulos

```typescript
//O caminho é relativo ao arquivo de onde sera feito o import
import { Spacecraft, Containership } from "./base-ships";
import { MillenniumFalcon } from "./starfighters";

let ship = new Spacecraft("Hiperdrive");
ship.jumpIntoHyperspace();

let falcon = new MillenniumFalcon();
falcon.jumpIntoHyperspace();
```

```typescript
interface Containership {
    cargoContainers: number;
}

// Para que o arquivo seja um modulo typescript, basta colocar um export
// passando o nome das classes/interfaces... a serem exportadas no fim do arquivo.
// Pode-se tambem colocar a palavra chave export na frente das classes e etc
// a serem exportadas.
export { Containership };
```

### Definição de tipos

-   Tratam-se de arquivos que definem os tipos de uma biblioteca feita em javascript, para que o typescript possa reconhecer.
-   \*.d.ts
-   Voce pode obter essas definições de tipos usando o NPM

```sh
# Inicializa o npm no seu projeto
npm init

# Instala uma biblioteca ao seu projeto
# o parametro --save indica que a biblioteca é necessaria tanto
# em deseonvolvimento quanto em runtime
npm install --save lodash@4.14

# Instala uma definição de tipos para o lodash
# o --save-dev indica que é somente necessaria durante desenvolvimento
npm install --save-dev @types/lodash@4.14
```

## Angular JS

### Criar um novo projeto com o angular-cli

-   O prefixo é adicionado a cada componente que for criado, util quando usar varios componentes externos e ser capaz de diferenciar do seu.

```sh
ng new myangularproj --prefix=myap
```

### Estrutura de um projeto AngularJS

#### main.ts

-   Arquivo responsavel pelo bootstrap do projeto

#### polyfills.ts

-   Serve para incluir scripts que dão suporte e funcionalidades a browsers antigos.

#### src/app/app.module.ts

-   Se trata de um module em Angular, diferente de modulo em ECMAScript (TypeScript/JavaScript)

```typescript
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppComponent } from "./app.component";

// NgModule é um Decorator
// Decorator é uma função que serve para aplicar metadados
// a uma função,metodo,classe,argumentos de metodos.
// Nesse caso está sendo aplicada em uma classe AppModule
@NgModule({
    declarations: [AppComponent],
    imports: [BrowserModule],
    providers: [],
    //Diz qual dos componentes listados em declarations
    //que será responsavel pelo bootstrap da aplicação
    bootstrap: [AppComponent]
})
export class AppModule {}
```

### O que é um Componente

-   São pequenas partes independentes e reusaveis
-   São classes com um determinado clico de vida
-   Possuem um template para definir uma aparencia
-   Possuem um Selector(TAG) para ser usada em outras partes da aplicação

```typescript
import { Component } from "@angular/core";

//Decorator
@Component({
    //  O nome da TAG html
    selector: "app-first",
    // Definição do template usando um arquivo externo
    // Pode ser usado tambem passando uma URL Http
    templateUrl: "./myfirst.component.html",

    // Segunda forma de definição do template
    // Definindo-a direto no decorator
    // Recomendado apenas se o template for pequeno e simples
    template: "<h1>my first component</h1>",

    // Com multiplas linhas, se usa o ``
    // Templates podem ter expressões que resolvem
    // as propriedades dos componentes, chamado de String Interpolation
    template: `
        <h1>{{ title }}</h1>
        <p>Welcome, {{ user.name }}!</p>
    `
})
export class MyFirstComponent {
    title: string = "My Star Wars Component!";
    user = { name: "Luke Skywalker" };
    constructor() {}
}
```

#### Informando ao angular em qual módulo o componente pertence

```typescript
@NgModule({
    declarations: [MyFirstComponent]
})
export class AppModule {}
```

#### Adicionando um novo componente ao projeto angular

-   O comando abaixo irá gerar um novo diretorio em src/app/
-   Irá criar 3 arquivos {html,css,ts}
-   Automaticamente vai adicionar o componente ao modulo raiz AppModule

```sh
# o --skipTests=true irá fazer com que não crie arquivos de teste
# para o novo componente.
# Obs: Use --spec=false caso use uma versão antiga do angular-cli
ng generate component nomeDoComponente --skipTests=true

# Versão reduzida
ng g c nomeDoComponente --skipTests=true

# Criando um componente dentro de outro
# Seu uso é comum quando o componente está muito relacionado a outro
ng g c restaurants/restaurant --skipTests=true
```

#### Property Binding

-   Serve para linkar o valor da propriedade de um elemento, a uma expressao angular
-   Sintaxe com []
-   Pode ser aplicada a qualquer propriedade do [DOM](https://www.w3schools.com/whatis/whatis_htmldom.asp)

```typescript
//No componente
user = {
    name: "Luke Skywalker",
    isJedi: true
};
```

```html
<!--No template do coponente-->
<!--Sempre que o valor de user mudar, vai mudar no input tambem-->
<input type="text" [value]="user.name" />

<!--Se o user não for um jedi, essa div sera ocultada-->
<div [hidden]="!user.isJedi">
    <!-- Pequena nota sobre html/css
    A propriedade hidden do DOM é controlada via CSS
    Então se voce alterar o display da Div em um CSS global
    pode influenciar na visibilidade desse elemento.
    -->
    location of the jedi temple
</div>

<!--Caso isJedi for true, o angular vai adicionar a classe light na div -->
<div [class.light]="user.isJedi"></div>
<div class="light"></div>
```

#### Passando dados aos componentes

-   Atribuição de valores as propriedades do componente

```typescript
// Deve se importar o decorator Input
import { Component, Input } from "@angular/core";

@Component({
    selector: "mt-header",
    template: "<h1>{{title}}</h1>"
})
export class HeaderComponent {
    // Adicionando o decorator input ao atributo
    @Input() title: string;

    //Pode-se tambem expor o atributo com outro nome
    @Input("value") title: string;

    @Input() randomBool: boolean;
}
```

```html
<!--usando o header em outro componente-->
<mt-header title="Minha App"></mt-header>

<!--Resultado do codigo acima no DOM -->
<mt-header title="Minha App">
    <!--Template do component-->
    <h1>Minha App</h1>
</mt-header>

<!--Usando template interpolation-->
<mt-header title="{{isJedi ? 'Jedi' : 'Sith'}}"></mt-header>

<!--Usando property binding-->
<mt-header [title]="isJedi ? 'Jedi' : 'Sith'"></mt-header>

<!--Usando o nome definido em @Input-->
<mt-header value="Título"></mt-header>

<!--Para passar um boleano, numero ou qualquer coisa diferente de uma string literal-->
<!--Voce deve usar property binding, senão rambomBool recebe a string "true"-->
<mt-header title="Exemplo" [randomBool]="true"></mt-header>
```

### Diretivas

-   Componentes são diretivas com template.
-   Servem para adicionar comportamento a um elemento do DOM.
-   Existem 3 tipos de diretivas: componentes, estruturais e de atributos.

#### Diretiva ngIf

-   Diretiva estrutural, trabalha com o padrão de template do HTML5
-   Permite renderizar um conteudo caso a expressão associada seja verdadeira.
-   Alternativa melhor ao uso da propriedade 'hidden' do DOM.

```html
<!--ng if -->
<input type="text" [value]="user.name" />
<!--Uso de forma abreviada, com o * na frente (recomendada)-->
<div *ngIf="user.isJedi">
    location of the jedi temple
</div>

<!--Versão não-abreviada-->
<input type="text" [value]="user.name" />
<template [ngIf]="user.isJedi">
    <div>
        location of the jedi temple
    </div>
</template>
```

#### Diretiva ngFor

-   Irá repetir o conteudo de um elemento para cada item de uma coleção de objetos.
-   Por ser estrutural irá repetir o template do elemento.

```html
<!--ng for-->
<ul>
    <li *ngFor="let user of users">{{user.name}}</li>
</ul>

<!--nf for com index-->
<ul>
    <li *ngFor="let user of users; let i=index">
        {{i+1}} - {{user.name}}
    </li>
</ul>
```

#### Diretiva ngSwitch

-   Avalia uma expressão.
-   Usa da diretiva ngSwitchCase para mostrar o conteudo equivalente.
-   Funcionamento semelhante a um switch case comum em programação.

```html
<div [ngSwitch]="profile">
    <p *ngSwitchCase="root">You can read & write</p>
    <p *ngSwitchCase="user">You can read</p>
    <p *ngSwitchDefault>go back, please!</p>
</div>
```

### Operador de Navegação segura

-   Operador '?'
-   Evita que erros/warnings surgem no Console do browser ao ler uma propriedade de algo não definido.

```html
<div>
    <!--Caso student seja Undefined, não irá tentar ler a propriedade nome-->
    Student: {{student?.name}}
    <div *ngIf="student?.isJedi">
        Jedi Temple: {{student?.temple}}
    </div>
</div>
```

### Eventos de um componente

-   Sem diretivas ng-\*
-   sintaxe - '()'
-   Usa-se () ao redor de um evento para linkar a um metodo de um componente

```typescript
import { Component } from '@angular/core'

@Component({
    selector: 'mt-clickable',
    template: '<button (click)="clicked()">Click!</button>',

    // Pode se tambem passar uma referencia ao evento usando $event
    // que será passado ao metodo, e então poderá ser inspecionado.

    // Em certos tipos de evento como keydown, voce pode associar a tecla
    // separado por ponto.
    template: '<input (keydown.space)="keyDown($event)">'
})
export class ClickableComponent {
    clicked(): void {
        console.log("Button clicked!")'
    }
    keyDown(event): void {
        console.log(`Key down: ${event}`)
    }
}
```

### Emitindo eventos em um Componente

```typescript
import { Component, Output, EventEmitter } from "@angular/core";

@Component({
    selector: "mt-clickable",
    template: '<button (click)="clicked()">Click!</button>'
})
export class ClickableComponent {
    // O decorator Output, ao inves de dizer que a propriedade recebe valores,
    // significa que ela emite eventos, a saida do componente.

    // O nome do evento por padrão é o nome da propriedade.
    @Output() myEvent = new EventEmitter();

    clicked(): void {
        //Emite de fato o evento
        this.myEvent.emit();
    }

    //Metodo que sera executado quando o myEvent for disparado
    willBeCalled(): void {
        console.log("Event from clickable");
    }
}
```

```html
<!--no template que usa o componente-->
<mt-clickable (myEvent)="willBeCalled()"></mt-clickable>
```

### Váriaveis de template

-   Servem para criar uma referencia a um elemento do DOM ou componente.
-   Permite usar uma referencia do elemento dentro do template HTML, ou passar como parametro a um método.
-   Prefixo #

```html
<!--Exemplo feito no arquivo src/app/student/student.component.html-->
<div *ngIf="student">
    Student: <a href="#" (click)="clicked()">{{student?.name}}</a>
    <div *ngIf="student?.isJedi">
        Jedi Temple: {{student?.temple}}
        <!--Uso da referencia de textarea-->
        <button (click)="description.focus()">Focus!</button><br />
        <!--Declaração da variavel de template description-->
        <textarea #description></textarea>
    </div>
</div>
<p *ngIf="!student">
    Sem dados para exibir
</p>
```

### Rotas

-   Tornam a pagina dinamica.
-   Permite que troque um componente para outros em seu lugar.
-   É necessario mapear cada componente em uma rota.
-   Uso do Tipo Routes do AngularJS.
-   Uso da diretiva routerLink para navegar nas rotas.

```html
<!-- No template do componente -->
<div>
    <!-- Componente fixo -->
    <mt-header></mt-header>
</div>
<div>
    <!-- Componente dinamico usando rotas -->
    <router-outlet></router-outlet>
</div>
```

```typescript
// Arquivo src/app/app.routes.ts
import { Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { AboutComponent } from "./about/about.component";

export const ROUTES: Routes = [
    { path: "", component: HomeComponent },
    { path: "about", component: AboutComponent }
];
```

```typescript
// Arquivo src/app/app.modules.ts
import { RouterModule } from "@angular/router";

import { ROUTES } from './app.routes';

@NgModule({
    declarations: [...],
    imports: [..., RouterModule.forRoot(ROUTES)],
})
export class AppModule { }
```

#### routerLink

-   É uma diretiva
-   Diretiva usada para poder navegar pelas rotas
-   Recebe o respectivo caminho

```html
<!-- no template de algum componente, passando o caminho -->
<a routerLink="/restaurants">Restaurantes</a>
<!-- ou usando property binding e passando um array -->
<a [routerLink]="['/restaurants']">Restaurantes</a>
```

#### routerLinkActive

-   É uma diretiva
-   Aplica uma classe CSS a um elemento quando uma rota estiver ativa.
-   Pode ser usado em qualquer elemento pai relativo a onde está o routerLink.

```html
<!-- Descrição de comportamento:
    Nesse exemplo, quando for no texto Sobre, localizado em uma barra
    de navegação, ele irá exibir o componente About e o routerLinkActive
    vai aplicar uma classe CSS chamada 'active' no elemento 'li' relativo ao
    routerLink, que irá destacar o "botão" do Sobre.
-->
<div class="collapse navbar-collapse pull-left" id="navbar-collapse">
    <ul class="nav navbar-nav">
        <li routerLinkActive="active"><a href="#">Restaurantes</a></li>
        <li routerLinkActive="active">
            <a [routerLink]="['/about']">Sobre</a>
        </li>
    </ul>
</div>
```

### Injeção de Dependência

-   É um padrão de projeto
-   A aplicação deixa de instanciar seus objetos manualmente e passa a depender do framework para obter os objetos que ela quer usar.
-   O framework gerencia a instanciação dos objetos, assim como suas dependencias, disponibilizando para os componentes da aplicação.

```typescript
@Component({
    // Informando ao angular o que será injetado
    // Para o componente e os filhos.
    providers: [MyFirstService],

    // Informando ao angular o que será injetado
    // Somente para o componente
    viewProviders: [MyFirstService]
})
export class MyFirstComponent {
    // Ao invés de instanciar um servico/dependencia dentro
    // do construtor, o componente pode receber o serviço
    // diretamente pronto como argumento, a vantagem é que
    // se o serviço depender de outro objeto, o componente não
    // precisa se preocupar em instancia-lo
    // constructor() {this.firstService = new MyFirstService}

    constructor(private firstService: MyFirstService) {}
}
```

```typescript
// Informando ao angular o que será injetado
// diretamente no Modulo, irá se aplicar a mesma instancia
// a todos os componentes nesse Modulo
@NgModule({
    declarations: [...],
    providers: [ MyFirstService ]
})
export class AppModule {}
```

### Serviços

-   Classes que podem ser usadas para injetar em outros componentes ou serviços.
-   São geralmente usados para encapsular o acesso a API's de backend.
-   Podem ser singletons: são otimos candidatos a guardar dados compartilhados para toda a aplicação.
-   Tambem podem guardar dados para somente parte de uma aplicação.

```typescript
import { Injectable } from "@angular/core";
import { Http } from "@angular/http";

// Decorator, não é necessario para que o seu serviço seja
// injetado em outro objeto, mas sim para que ele possa receber
// injeções do framework
@Injectable()
export class MyService {
    constructor(private http: Http) {}

    list() {
        return this.http.get("/url");
    }
}
```

### Alguns serviços

#### Title

-   Serviço para obter e alterar o titulo de uma página.
-   Um componente pode requisitar a injeção e usar um método para trocar o titulo.
-   Esse serviço existe porque não é possivel usar expressoes angular na pagina html inteira, como o titulo fica no Head e essa parte não faz parte do bootstrap, foi criado o serviço title.

```typescript
import { Title } from "@angular/plataform-browser";

@Component({
    viewProviders: [Title]
})
export class MyPageComponent {
    constructor(title: Title) {
        title.setTitle(":: MyFancy Title ::");
    }
}
```

#### Http

#### Router

### Métodos do ciclo de vida - OnInit

-   Sempre que é criado um componente com o angular-cli, ele automaticamente implementa a interface OnInit.
-   O método ngOnInit() será chamado uma vez no clico de vida do componente.

```typescript
import { Component, OnInit } from "@angular/core";
import { Restaurant } from "./restaurant/restaurant.model";
import { RestaurantsService } from "./restaurants.service";

@Component({
    selector: "mt-restaurants",
    templateUrl: "./restaurants.component.html"
})
export class RestaurantsComponent implements OnInit {
    restaurants: Restaurant[];

    constructor(private restaurantsService: RestaurantsService) {}

    // Sempre que o componente entrar na tela, e todas as dependencias e
    // injeções tiverem sido atribuidas ao componente, o metodo ngOnInit
    // será chamado pelo angular
    ngOnInit() {
        // Momento ideal para fazer a inicialização do componente
        this.restaurants = this.restaurantsService.restaurants();
    }
}
```

### Reactive Programming

-   Resumidamente a ideia é, quando um evento acontecesse, os interessados são notificados e reagem a ele.
-   Baseado em eventos
-   Os eventos veem em forma de Streams, uma sequencia de eventos que podem ser modificados ou transformados em uma nova cadeia de eventos.
-   REACTIVE = ITERATOR(Passa item por item na stream) + OBSERVER(notifica os listeners interessados)
-   Angular utiliza da biblioteca RXJS para Reactive Programming

#### RXJS

-   Os metodos da api http retornam Observable<Response>, um dos objetos principais do RXJS.
-   Permite coisas interessantes como, por exemplo, facilmente refazer as chamadas http usando o método retry de Observable.
-   Permite fazer multiplos mapeamentos até que a resposta seja da forma como voce espera.

```typescript
this.http
    .get("/url")
    .retry(2)
    .map(response => response.json())
    .subscribe(data => (this.mydata = data));

this.http
    .post("/url", JSON.stringify(myData))
    .map(response => response.json())
    .map(result => result.id)
    .subscribe(id => (this.id = id));
```

#### Observable vs Promises

-   Observables continuam disparando eventos até que sejam explicitamente fechados.
-   Promises são consideradas resolvidas depois do primeiro evento.
-   Observables são mais flexiveis, pois, por exemplo, possuem capacidade de usar WebSockets.

#### Subscribe/Unsubscribe

-   Quando um objeto se inscreve em um Observable, é necessario remover a inscrição posterior para evitar Memory Leaks.
-   Mesmo quando um componente sai da tela, um listener que foi inscrito pode continuar sendo chamado.
-   Os Observable retornados pela API http, pelos parametros do router e pelo pipe Async, não precisam de cancelamento de inscrição.

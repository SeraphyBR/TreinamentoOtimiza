# Nota das aulas do curso De Angular (4,5,6) - Otimiza

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

#### polyfills.ts

-   Serve para incluir scripts que dão suporte e funcionalidades a browsers antigos.
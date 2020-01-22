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

-   parametros => implementacao
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

//Informando um valor default logo na declaração
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

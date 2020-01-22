class Spacecraft {
    //Propriedade publica
    propulsor: string;

    constructor (propulsor: string){
        this.propulsor = propulsor;
    }

    //Para definir um metodo não precisa da palavra chave function
    jumpIntoHyperspace() {
        console.log("Entering hyperspace with " + this.propulsor);
    }
}

interface Containership {
    cargoContainers: number;
}

export {Spacecraft, Containership};
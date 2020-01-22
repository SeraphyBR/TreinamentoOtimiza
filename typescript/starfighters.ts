import {Spacecraft, Containership} from './base-ships';

class MillenniumFalcon extends Spacecraft implements Containership {

    cargoContainers: number;
    constructor() {
        super("hyperdrive");
        this.cargoContainers = 4;
    }

    //Sobrescrita do metodo da classe Spacecraft
    jumpIntoHyperspace(){
        if(Math.random() >= 0.5) {
            //Chamada do metodo da classe pai/super
            super.jumpIntoHyperspace();
        }
        else {
            console.log("Failed");
        }
    }
}

export {MillenniumFalcon};
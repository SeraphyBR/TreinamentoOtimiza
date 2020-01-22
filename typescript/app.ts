import { Spacecraft, Containership } from "./base-ships";
import { MillenniumFalcon } from "./starfighters";

import * as _ from "lodash";
console.log(_.pad("Typescript Examples", 40, "="));
let ship = new Spacecraft("Hiperdrive");
ship.jumpIntoHyperspace();

let falcon = new MillenniumFalcon();
falcon.jumpIntoHyperspace();

let goodForTheJob = (ship: Containership) => ship.cargoContainers > 2;
console.log(
    `Is Falcon good for the job? ${goodForTheJob(falcon) ? "yes" : "no"}`
);

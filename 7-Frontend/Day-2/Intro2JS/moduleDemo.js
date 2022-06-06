import { Pokemon, ThisIsAFunction } from "./module1";
//Modules is like the using statement in C#
//It lets you use different functions, classes, etc. in another JS file

function CreateCharizard() {
    //We just created a pokemon object using a class Pokemon from another JS file
    let pokemon = new Pokemon();

    console.log(pokemon.health);
    console.log(pokemon.name);
    console.log(pokemon.type);

    //We can use other function from another JS file as well
    ThisIsAFunction();
}
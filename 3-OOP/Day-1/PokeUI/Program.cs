// See https://aka.ms/new-console-template for more information
using PokeModel;

//Checking if creating out models is working
Pokemon poke1 = new Pokemon();
Console.WriteLine(poke1);
Console.WriteLine(poke1.Abilities[0]);
// List<Ability> abilityList = new List<Ability>();
// poke1.Abilities = abilityList; //Our validation is working

Ability ability1 = new Ability();
// ability1.PP = 0; //Our validation is working
Console.WriteLine(ability1);
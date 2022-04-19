import { Component } from "@angular/core";
import { Pokemon } from "../models/pokemon.model";

@Component({
    selector:'app-pokemon-list',
    templateUrl: './pokemon-list.component.html',
    styleUrls: ['./pokemon-list.component.css']
})
export class PokemonListComponent {
    title:string = "List of Pokemon";
    src1:string = "https://upload.wikimedia.org/wikipedia/commons/6/6a/Door_Tree_1898.png";
    isImageVisible:boolean = true;
    isPokeSearched:boolean = false;
    
    foundPokemon: Pokemon;
    listOfPokemon:Pokemon[];

    constructor() {
        this.listOfPokemon = [{
            id:132,
            base_experience: 101,
            name: 'ditto',
            rating: 5,
            sprites: {
                front_default: 'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/132.png'
            }
        },
        {
            id:25,
            base_experience: 112,
            name: 'pikachu',
            rating: 3.2,
            sprites: {
                front_default: 'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/25.png'
            }
        }];
        
        this.foundPokemon = {
            id: 0,
            base_experience: 0,
            name: 'default',
            sprites: {
                front_default: ''
            }
        };
    }

    changeTitle()
    {
        this.title = "title has been changed!";
        this.src1 = "https://upload.wikimedia.org/wikipedia/commons/5/56/Hudson_Yards_from_Hudson_Commons_%2895131p%29.jpg";
        this.listOfPokemon.push({base_experience:64, id:1,name:'bulbasaur',sprites:{front_default:'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png'}});
    }

    changeImageVisible()
    {
        this.isImageVisible = !this.isImageVisible;
    }

    changeSearchVisible()
    {
        this.isPokeSearched = true;
    }

    AddPokeToList()
    {
        this.isPokeSearched = false;
    }

    NoAddPokeToList()
    {
        this.isPokeSearched = false;
    }
}
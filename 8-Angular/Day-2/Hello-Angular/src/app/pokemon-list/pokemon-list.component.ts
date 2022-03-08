import { Component } from "@angular/core";
import { faStar } from "@fortawesome/free-solid-svg-icons";
import { Pokemon } from "../models/pokemon.model";
import { PokeService } from "../services/poke.service";

@Component({
    selector:'app-pokemon-list',
    templateUrl: './pokemon-list.component.html',
    styleUrls: ['./pokemon-list.component.css']
})
export class PokemonListComponent {
    title:string = "List of Pokemon";
    src1:string = "https://upload.wikimedia.org/wikipedia/commons/6/6a/Door_Tree_1898.png";
    isVisible:boolean = true;

    listOfPokemon:Pokemon[] = 
    [{
        id:132,
        base_experience: 101,
        name: 'ditto',
        sprites: {
            front_default: 'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/132.png'
        }
    },
    {
        id:25,
        base_experience: 112,
        name: 'pikachu',
        sprites: {
            front_default: 'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/25.png'
        }
    }];

    listOfPokeTest: any[]; 

    faStar = faStar;

    constructor(poke:PokeService) {
        this.listOfPokeTest = [];
        // poke.getAllPoke().subscribe(result => this.listOfPokeTest = result);
    }

    changeTitle()
    {
        this.title = "title has been changed!";
        this.src1 = "https://upload.wikimedia.org/wikipedia/commons/5/56/Hudson_Yards_from_Hudson_Commons_%2895131p%29.jpg";
        this.listOfPokemon.push({base_experience:64, id:1,name:'bulbasaur',sprites:{front_default:'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png'}});
    }

    changeVisible()
    {
        this.isVisible = !this.isVisible;
    }
}
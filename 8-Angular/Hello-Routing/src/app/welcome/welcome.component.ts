import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms'; //This is a type of reactive form in Angular
import { Router } from '@angular/router';
import { PokeService } from '../services/poke.service';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {

  currentPokemon:string = "No pokemon";

  pokeGroup = new FormGroup({
    id: new FormControl(""),
    name: new FormControl("")
  });

  constructor(private router:Router, private pokeServ: PokeService) { }

  swapView()
  {
    this.router.navigate(["/superheroes"]);
  }

  pokeGetOne(): void
  {
    this.pokeServ.retrievePokemon().subscribe( //Subscribe method will give a response everytime the publisher publishes an event
      (response) => {
        console.log(response);
        this.currentPokemon = response["name"];
      }
    )
  }

  pokeGetTwo(): void
  {
    this.pokeServ.retrievePokemonTwo().subscribe( //Creating an interface allows us to have specific information from that observable
      (response) => {
        console.log(response.name);
        console.log(response.id);
        console.log(response.base_experience);
        this.currentPokemon = `name: ${response.name} id: ${response.id} base experience: ${response.base_experience}`;
      }, (error) => {
        console.log(error);
        /*
          I would create a boolean variable
          this boolean variable will dictate if a certain DOM element to appear using *ngIf
        */
      }
    )
  }

  pokeGetThree(pokeGroup: FormGroup): void
  {
    if(pokeGroup.get("name").value) //Note: remember how string truthy and falsy work
    {
      this.pokeServ.retrievePokemonThree(pokeGroup.get("name").value).subscribe(
        (response) => {
          this.currentPokemon = `name: ${response.name} id: ${response.id}`;
        }
      )
    }
    else if(pokeGroup.get("id").value)
    {
      this.pokeServ.retrievePokemonThree(pokeGroup.get("id").value).subscribe(
        (response) => {
          this.currentPokemon = `name: ${response.name} id: ${response.id}`;
        }
      )
    }
    else
    {
      this.currentPokemon = "Pokemon not found";
    }
  }
  
  ngOnInit(): void {
  }

}

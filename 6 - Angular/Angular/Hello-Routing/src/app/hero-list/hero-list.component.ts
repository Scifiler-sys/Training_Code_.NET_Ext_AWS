import { Component } from "@angular/core";
import { HeroService } from "../services/hero.service";
import { ISuperhero } from "./hero";

@Component({
    /*
        The selector property tells Angular to create and insert an instance of this component to whatever it finds the corresponding tag in template HTML
    */
    selector: 'app-hero-list',
    /*
        It links this TS file with the HTML file in the same folder
        as you know, the HTML will be the visualization of the view that this component controls
    */
    templateUrl: './hero-list.component.html',
    styleUrls: ['./hero-list.component.css']
})
export class HeroListComponent //Export keyword will export this class so it can be imported
{
    title:string = "Super Hero List";
    superheroes: ISuperhero[];
    isVisible:boolean = false;

    heroListFilter:string = ""; //This variable will be filled by an input tag value in HTML
    filteredSuperheroes: ISuperhero[]; //This list will dynamically change depending on what is on heroList

    constructor(private heroServ: HeroService)
    {
        this.superheroes = heroServ.getSuperHeroes(); //Hero Service gets the hard coded array values and puts it on superheroes

        this.filteredSuperheroes = this.superheroes;
    }

    public get HeroListFilter(): string
    {
        return this.heroListFilter;
    }

    public set HeroListFilter(s1: string)
    {
        this.heroListFilter = s1;
        //String truthy and falsy
        this.filteredSuperheroes = this.heroListFilter ? this.performFilter(this.heroListFilter) : this.superheroes;
    }

    toggleImage(): void //This will show or hide the images of the HTML
    {
        this.isVisible = !this.isVisible;
    }

    starEventWasTriggered(s1:string)
    {
        this.title = s1;
    }

    performFilter(filterBy:string): ISuperhero[]
    {
        filterBy = filterBy.toLowerCase();

        /*
            -filter function from the array object will return a new array that pass some sort of condition
            -The condition is, we check each hero in the superheroes array (specifically the name of the hero) 
            and we lowercase it (so it isn't capitalize sensitive)
            -indexOf function will return the index of the string given a search value
            Ex: if you have a "Hello" as a string, if oyu give a search value of "el" it will give an index value of of 1
            IF it can't find it, it will give you a -1 value
        */

        let tempHeroes: ISuperhero[];
        tempHeroes = this.superheroes.filter((hero:ISuperhero) => hero.name.toLowerCase().indexOf(filterBy) !== -1)

        return tempHeroes;
    }
}
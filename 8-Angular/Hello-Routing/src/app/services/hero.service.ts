import { Injectable } from '@angular/core';
import { ISuperhero } from '../hero-list/hero';

@Injectable({
  providedIn: 'root' //This providedIn property from the Injectable will provide the service in the root module (meaning we don't have to put it on app.module.ts)
})
export class HeroService {

  constructor() { }

  getSuperHeroes() : ISuperhero[]
  {
    return [{ //Hard coded values to add in our ISuperhero array
        name: 'Frozone',
        rank: 4,
        ability: 'cold generation',
        organization: 'incredibles',
        image: 'http://www.cultjer.com/img/ug_photo/2014_03/sf2_lg20140331142439.jpg'
    },
    {
        name: 'Eraser Head',
        rank: 5,
        ability: 'power nullification',
        organization: 'pro hero',
        image: 'https://media.tenor.co/images/788cc935108fb487b6af1e152bcec6bf/raw'
    },
    {
        name: 'Static Shock',
        rank: 4.7,
        ability: 'electric manipulation',
        organization: 'duo',
        image: 'https://t00.deviantart.net/CsfqTmmnwQAltUe4HYS8A7gsk-s=/300x200/filters:fixed_height(100,100)' +
            ':origin()/pre00/64ea/th/pre/f/2012/125/4/1/static_shock_by_deshockwav-d4ynm1o.png'
    },
    {
        name: 'Saitama',
        rank: 2.3,
        ability: 'punches',
        organization: 'the hero association',
        image: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTnx0maPoLAqImOmsoTnxRwBronngiLYfeOVYFSSs2UBLsjXDDT&s'
    }];
  }
}

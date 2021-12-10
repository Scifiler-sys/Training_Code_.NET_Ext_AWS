import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { PokeapiService } from '../services/pokeapi.service';
import { By } from "@angular/platform-browser";

import { PokemonComponent } from './pokemon.component';
import { Observable } from 'rxjs';

describe('PokemonComponent', () => {
  let component: PokemonComponent;
  let fixture: ComponentFixture<PokemonComponent>;
  let pokeService: PokeapiService

  class MockService
  {
    getPikachu(){};
    getPokemon(){};
  }

  const dummyPokeData =
  {
    name: "pikachu",
    id: 25,
    base_experience:100,
    sprites: []
  }

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PokemonComponent ],
      providers: [{provide: PokeapiService, useClass: MockService}]
    })
    .compileComponents();

    pokeService = TestBed.inject(PokeapiService);
  }));

  beforeEach(() => {
    //fixture variable mimics the lifecycle hooks of a component
    //TestBed.createComponent() will just create that welcome component in our testing environment and have fixture be attached to that particular component
    fixture = TestBed.createComponent(PokemonComponent);

    //component variable will point to the welcome that we just created
    component = fixture.componentInstance;

    //Well this is the manual way of telling the component to do the ngOnChange() method
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it("p should have 'No Current Pokemon' when the component is first created", () => {
    //This will grab the paragraph tag in the pokemon.component.html
    let paragraph: HTMLElement = fixture.debugElement.query(By.css('p')).nativeElement;

    //this will check that the paragraph tag will have 'No Current Pokemon'
    expect(paragraph.innerHTML).toBe("No Current Pokemon");
  });

  it("p should have 'pikachu' when the component is first created", () => {
    //This will grab the paragraph tag in the pokemon.component.html
    let paragraph: HTMLElement = fixture.debugElement.query(By.css('p')).nativeElement;
    component.currentPokemon.name = "pikachu";

    fixture.detectChanges();
    //this will check that the paragraph tag will have 'No Current Pokemon'
    expect(paragraph.innerHTML).toBe("pikachu");
  });

  it("should fetch getPikachu async data", async(() => {
    //Will gaurantee to give a observable response of the dummy data we created
    spyOn(pokeService, "getPikachu").and.returnValue(Observable.create((observable) => {
      observable.next(dummyPokeData);
    }));

    let button = fixture.debugElement.query(By.css("#buttonOne")).nativeElement;
    button.click();
    fixture.detectChanges();

    let paragraph : HTMLElement = fixture.debugElement.query(By.css("p")).nativeElement;

    
    fixture.whenStable().then(() => {
      expect(paragraph.innerHTML).toBe("pikachu");
    });
  }));

});

import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { Router } from '@angular/router';
import { PokeService } from '../services/poke.service';
import {RouterTestingModule} from "@angular/router/testing";

import { WelcomeComponent } from './welcome.component';
import { By } from '@angular/platform-browser';
import { Observable } from 'rxjs';

describe('WelcomeComponent', () => {
  let component: WelcomeComponent;
  let fixture: ComponentFixture<WelcomeComponent>; //This emulates the lifecycle of a component
  let router: Router;
  let pokeService: PokeService;

  const dummyPokeData =
  {
    name: "scyther",
    id: 123,
    base_experience: 100
  }

  class MockService //MockService is here to provide zero implemtation to PokeService
  {
    retrievePokemon(){};
    retrievePokemonTwo(){};
    retrievePokemonThree(){};
  }

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WelcomeComponent ],
      imports: [RouterTestingModule.withRoutes([])], //RouterTestingModule instead of the real module for testing purposes
      providers:[
        {provide: PokeService, useClass: MockService},
      ]
    })
    .compileComponents();
    fixture = TestBed.createComponent(WelcomeComponent); //Points the fixture to the Welcome component that we just created in the testing environment
    component = fixture.componentInstance;
    fixture.detectChanges(); //It will tell our TestBed to perform any data binding being used in that component

    router = TestBed.inject(Router);
    pokeService = TestBed.inject(PokeService);
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WelcomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  //We will test that the <p> in welcome.component.html will have "No pokemon"
  it("should have 'No pokemon' when a request has not been made", () => {
    //This will specifically get any <p> tag DOM element in welcome.component.html
    let pokePara = fixture.debugElement.query(By.css("p")).nativeElement;
    expect(pokePara.innerHTML).toBe("No pokemon");
  })

  //We will just test that interpolation in that p tag element is working
  it("should have 'scyther' when a request has been made", () => {
    component.currentPokemon = "scyther";
    fixture.detectChanges();

    let pokePara = fixture.debugElement.query(By.css("p")).nativeElement;
    expect(pokePara.innerHTML).toBe("scyther");
  })

  //We will just test that clicking the Get Scyther button will use the pokeGetOne() function
  //waitForAsync() just makes it so that our test will be completed once all asynchronous calls are done
  it("should call pokeGetOne()", waitForAsync(() =>{
    let pokeButton = fixture.debugElement.query(By.css("#buttonOne")).nativeElement;
    spyOn(component, "pokeGetOne"); //Will basically tell Jasmine that when that function is called just do nothing instead (Don't do the implentation)
    pokeButton.click(); //Simulates us clicking the button

    fixture.whenStable().then(() => {
      expect(component.pokeGetOne).toHaveBeenCalled();
    })
  }))

  //Once we called pokeGetOne() it should fetch async data
  it("should fetch pokeGetOne async data", waitForAsync(() => {

    //spyOn will check the retrievePokemon() and instead of doing its implementation details, 
    //it will instead give us a gauranteed return observable that the function was suppose to do
    spyOn(pokeService, "retrievePokemon").and.returnValue(Observable.create((observable) => { 
      observable.next(dummyPokeData);
    }))

    let pokeButton = fixture.debugElement.query(By.css("#buttonOne")).nativeElement;
    pokeButton.click();
    fixture.detectChanges();

    let pokePara = fixture.debugElement.query(By.css("p")).nativeElement;

    fixture.whenStable().then(() =>{
      expect(pokePara.innerHTML).toBe("scyther");
    })
  }))
});

import { ComponentFixture, TestBed, waitForAsync} from '@angular/core/testing';

import { WelcomeComponent } from './welcome.component';
import { RouterTestingModule } from "@angular/router/testing";
import { PokeService } from '../services/poke.service';
import { Router } from '@angular/router';
import { By } from '@angular/platform-browser';
import { HtmlParser } from '@angular/compiler';
import { observable, Observable, of } from 'rxjs';
import { IPokemon } from '../services/poke';

describe('WelcomeComponent', () => {
  let component: WelcomeComponent;
  let fixture: ComponentFixture<WelcomeComponent>;
  let pokeService: PokeService;
  let router: Router;

  const dummyPokeData =
  {
    name:"scyther",
    id: 123,
    base_experience: 100
  }

  class MockService 
  {
    retrievePokemon(){};
    retrievePokemonTwo(){};
    retrievePokemonThree(){};
  }

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RouterTestingModule],
      declarations: [ WelcomeComponent ],
      providers: [
        {provide: PokeService, useClass: MockService}]
    })
    .compileComponents();

    router = TestBed.inject(Router);
    pokeService = TestBed.inject(PokeService);
  });

  beforeEach(() => {

    //the fixture variable mimics the lifecycle hook of a component
    //TestBed.createComponent - it will create the welcome component inside the testing environment
    fixture = TestBed.createComponent(WelcomeComponent);

    //component variable will then point to that Welcome component that we just created
    component = fixture.componentInstance;

    //Well this is the manual way of telling the component to do the ngOnChanges() method
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  //We will just test that the interpolation in that p tag element should have "No pokemon" in the beginning
  it("p should have 'No pokemon' when the component first created", () => {
    let welcomeParagraph: HTMLElement = fixture.debugElement.query(By.css('p')).nativeElement;

    expect(welcomeParagraph.innerHTML).toBe("No pokemon");
  });

  //We will just test that the interpolation in that p tag element is working
  it("p should have 'scyther' when we change the currentPokemon value", () => {
    component.currentPokemon = "scyther";

    let welcomeParagraph: HTMLElement = fixture.debugElement.query(By.css('p')).nativeElement;
    fixture.detectChanges();
    expect(welcomeParagraph.innerHTML).toBe("scyther");
  });

  //We will just test that pokeGetOne() method will be called if we press the button
  it("should call pokeGetOne() when button is pressed", waitForAsync(() => {

    let buttonOne = fixture.debugElement.query(By.css("#buttonOne")).nativeElement;
    spyOn(component, "pokeGetOne"); //If pokeGetOne() was used, do absolute nothing
    buttonOne.click(); //Simulates us clicking the button

    fixture.whenStable().then(() => {
      expect(component.pokeGetOne).toHaveBeenCalled();
    });
  }));

  //We will test if the pokeGetOne() method is working as intended
  it("should fetch pokeGetOne async data", waitForAsync(() => {
    spyOn(pokeService, "retrievePokemon").and.returnValue(Observable.create((observable) => {
      observable.next(dummyPokeData);
    }))

    let buttonOne = fixture.debugElement.query(By.css("#buttonOne")).nativeElement;
    buttonOne.click();
    fixture.detectChanges();

    let welcomeParagraph = fixture.debugElement.query(By.css("p")).nativeElement;

    fixture.whenStable().then(() => {
      expect(welcomeParagraph.innerHTML).toBe("scyther");
    });
  }));
});

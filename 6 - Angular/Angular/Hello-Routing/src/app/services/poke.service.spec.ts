import { TestBed } from '@angular/core/testing';
import {HttpTestingController, HttpClientTestingModule} from "@angular/common/http/testing";

import { PokeService } from './poke.service';

/*
  The testing environment is separate from our real environment
  Therefore, we have to manually again state what dependencies we will require in this separate environment 
*/

describe('PokeService', () => { 
  let service: PokeService;
  let httpMock: HttpTestingController; //It is basically a mock version of HttpClient used for testing purposes

  const dummyPokeData =
  {
    name: "scyther",
    id: 123,
    base_experience: 100
  }

  beforeEach(() => {
    TestBed.configureTestingModule({ //TestBed is our testing application's environment. It mimics the real angular environment 
      imports: [HttpClientTestingModule],
      providers: [PokeService]
    }); //.configureTestingModule() function is similar to an app.module.ts it will state what kind of dependencies we need
    service = TestBed.inject(PokeService);

    //We inject HttpTestingController into our testing application's environment 
    //Normally this is done by the Angular Injector but the testing environment doesn't use that so we have to do it manually
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it("should have retrieved data from retrievePokemon()", () => {
    service.retrievePokemon().subscribe((response) => {
      //Basically we will check that the response will be the expected dummy values that we stated above
      expect(response.toString()).toEqual(dummyPokeData.toString()); 
    })

    //This will check that our service will try to do a single request from this back-end server and return its mock to the req variable
    const req = httpMock.expectOne("https://pokeapi.co/api/v2/pokemon/123"); 
    //req.request.method will hold a string taht gives us the outgoing HTTP request as a string... toBe() matcher function just checks if it is holding "GET"
    expect(req.request.method).toBe("GET"); 
    req.flush(dummyPokeData); //Flush() will resolve our http request
  })
});

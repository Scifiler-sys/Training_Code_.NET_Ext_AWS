import { TestBed } from '@angular/core/testing';

import { PokeapiService } from './pokeapi.service';
import { HttpClientTestingModule, HttpTestingController } from "@angular/common/http/testing";

describe('PokeapiService', () => {
  let service: PokeapiService;
  let httpMock: HttpTestingController; // Mimic our HttpClient that poke service uses

  const dummyPokeData =
  {
    name: "pikachu",
    id: 25
  }

  beforeEach(() => {
    //TestBed it is our testing application's evirontment to simulate the real angular environment

    TestBed.configureTestingModule({ //.configureTestingModule() it is similar to @NgModule for the testing environment
      imports: [
        HttpClientTestingModule
      ],
      providers:[
        PokeapiService
      ]
    }); 
    service = TestBed.inject(PokeapiService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it("should have retrieved data from the getPikachu()", () =>{
    service.getPikachu().subscribe(
      (response) => {
        expect(response.name).toEqual("pikachu");
      }
    );

    //This will check that our service will try to do a single request from the url we provided
    const req = httpMock.expectOne("https://pokeapi.co/api/v2/pokemon/pikachu");
    expect(req.request.method).toBe("GET");
    req.flush(dummyPokeData); //We are gauranteeing that this url will give this dummyPokeData to our service that is subscribed.

  });
});

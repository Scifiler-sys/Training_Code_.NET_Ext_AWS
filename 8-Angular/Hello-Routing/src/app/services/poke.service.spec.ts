import { TestBed } from '@angular/core/testing';

import { PokeService } from './poke.service';
import { HttpClientTestingModule, HttpTestingController } from "@angular/common/http/testing";

describe('PokeService', () => { 
  let service: PokeService;
  let httpMock: HttpTestingController; //HttpTestingController mimicks HttpClient that poke services uses

  const dummyPokeData =
  {
    name: "scyther",
    id: 123,
    base_experience: 100
  }

  beforeEach(() => {
    //TestBed it is our testing application's environment to simulate a real angular environment
    //configureTestingModule() is equivalent or mimicks the app.module.ts

    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],  
      providers: [PokeService]
    });
    service = TestBed.inject(PokeService);

    //We inject HttpTestingController into our testing applicaiton's environment
    //Normally this is done by Angular Injector but the testing environment doesn't use that so we have to do it manually
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  //We should expect retrievePokemon() method will return the scyther data
  it("should have retrieved data from the retrievePokemon()", () => {
    service.retrievePokemon().subscribe( (response) => {
      //Basically we will check the response we got from the event channel will match our dummy data
      expect(response.toString()).toEqual(dummyPokeData.toString());
    });

    //This will check that our service will try to do a single request from the url we provided (back-end server of poke api)
    const req = httpMock.expectOne("https://pokeapi.co/api/v2/pokemon/123");
    //request.method just holds a string that gives us the outgoing Http request as a string... we should expect it to be GET method
    expect(req.request.method).toBe("GET");
    req.flush(dummyPokeData); //Flush() will resolve our HTTP request

  });

});

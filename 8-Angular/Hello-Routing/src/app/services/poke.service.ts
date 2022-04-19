import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { Observable, throwError } from 'rxjs';
import {catchError} from "rxjs/operators";
import { IPokemon } from './poke';

@Injectable({
  providedIn: 'root'
})
export class PokeService {

  private url = "https://pokeapi.co/api/v2/pokemon/123"; //This url should give us Scyther
  private url2 = "https://pokeapi.co/api/v2/pokemon/"; //This url should give us any pokemon we want 

  constructor(private httpFly: HttpClient) { }

  retrievePokemon(): Observable<string>
  {
    return this.httpFly.get<string>(this.url);
  }

  retrievePokemonTwo(): Observable<IPokemon>
  {
    //catchError() will catch any error that httpclient will throw
    //it will then pass that error to our private errorHandler()
    return this.httpFly.get<IPokemon>(this.url).pipe(catchError(this.errorHandler));
  }

  retrievePokemonThree(poke:string): Observable<IPokemon>
  {
    return this.httpFly.get<IPokemon>(this.url2 + poke);
  }

  //It will give us a error with a message indicating what was the problem
  private errorHandler(error)
  {
    return throwError(error.message || "Server Error");
  }
}

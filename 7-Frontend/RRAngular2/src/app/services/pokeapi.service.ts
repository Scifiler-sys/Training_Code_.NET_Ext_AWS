import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { IPokemon } from "./poke";

@Injectable({
  providedIn: 'root'
})
export class PokeapiService {

  private url = "https://pokeapi.co/api/v2/pokemon/";

  constructor(private http: HttpClient) { }

  getPikachu() : Observable<IPokemon>
  {
    return this.http.get<IPokemon>(this.url + "pikachu");
  }

  getPokemon(poke: string) : Observable<IPokemon>
  {
    return this.http.get<IPokemon>(this.url + poke);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pokemon } from '../models/pokemon.model';

@Injectable({
  providedIn: 'root'
})
export class PokeService {
  private url = "https://pokedemo.azurewebsites.net/api/Pokemon/GetAll";

  constructor(private http: HttpClient) { }

  getAllPoke() : Observable<any[]>
  {
    return this.http.get<any[]>(this.url);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IRestaurant } from "./restaurant";

@Injectable({
  providedIn: 'root'
})
export class RrapiService {

  private url: string = "https://20.84.10.156/api/api/";

  constructor(private http: HttpClient) { }

  getAllRestaurant() : Observable<IRestaurant[]>
  {
    return this.http.get<IRestaurant[]>(this.url + "Restaurant");
  }

  addRestaurant(newRest: IRestaurant) : Observable<IRestaurant>
  {
    return this.http.post<IRestaurant>(this.url + "Restaurant/add", newRest);
  }

}

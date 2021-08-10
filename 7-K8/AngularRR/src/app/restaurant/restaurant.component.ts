import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { IRestaurant } from '../services/restaurant';
import { RrapiService } from "../services/rrapi.service";

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.css']
})
export class RestaurantComponent implements OnInit {

  restaurants: IRestaurant[];

  restGroup = new FormGroup({
    name: new FormControl(),
    city: new FormControl(),
    state: new FormControl()
  });

  constructor(private RRApi:RrapiService) { }

  ngOnInit(): void 
  {
    this.getAllRestaurant();
  }

  getAllRestaurant()
  {
    this.RRApi.getAllRestaurant().subscribe(
      (response) => {
        this.restaurants = response;
      }
    );
  }

  addRestaurant(restGroup: FormGroup)
  {
    let tempRest: IRestaurant =
    {
      name: restGroup.get("name").value,
      city: restGroup.get("city").value,
      state: restGroup.get("state").value,
      revenue: 0
    }

    this.RRApi.addRestaurant(tempRest).subscribe(
      (response) => {
        console.log(response["id"]);

        this.getAllRestaurant();
      }
    );
  }

}

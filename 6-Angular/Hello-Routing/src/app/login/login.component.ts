import { animate, style, transition, trigger } from '@angular/animations';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  animations: [
    trigger("fade", [ //This trigger will give a fade effect on the DOM element(s)
      transition("void => *", [
        style({opacity:0}), //This will apply the css style to the DOM element(s) immediately
        animate(500, style({opacity:1}))
      ])
    ]),
    
    trigger("move", [
      transition("void => *", [
        animate(200, style({transform: "translateX(5%)"})),
        animate(200, style({transform: "translateX(0)"}))
      ])
    ])
  ]
})
export class LoginComponent implements OnInit {

  name:string = "";
  password:string = "";
  phoneNumber:number = 0;

  constructor() { }

  onSubmit(value:any) //We will use this function to event bind the click button that we will create later
  {
    console.log(value);
  }

  ngOnInit(): void {
  }

}

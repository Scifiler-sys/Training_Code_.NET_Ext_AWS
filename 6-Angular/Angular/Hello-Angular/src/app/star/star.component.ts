import { Component, Input, OnInit, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-star',
  templateUrl: './star.component.html',
  styleUrls: ['./star.component.css']
})
export class StarComponent implements OnInit, OnChanges{ //Child component of the Hero-list component

  /*
    - The input decorator will make rank variable into an attribute of the app-star html tag
    -This allows us to send information from the parent component to the child component
    -This property decorator

    -The reason this will become a child component is because it will exist within the Hero-list component 
  */

  @Input()rank:number; 

  /*
    -The output decorator will emit a value to the parent component
    -In this case, we are sending a string value
  */
  @Output() starClick = new EventEmitter<string>();

  starWidth: number = 0;

  constructor() 
  { 
    this.rank = 0;
  }

  ngOnInit(): void {
  }

  ngOnChanges(changes: SimpleChanges) //This will call on it when the input property of the component changes
  {
    this.starWidth = this.rank*75/5;
  }

  onStarClick():void
  {
    console.log("Star has been clicked");
    this.starClick.emit("The width of star div is " + this.starWidth); //starClick Event Emitter will emit a string value for the parent component
  }

}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  currentHero: string = "No Hero";

  constructor(private route: ActivatedRoute) { } //Angular will automatically pass a value to this variable

  ngOnInit(): void {
    this.currentHero = this.route.snapshot.paramMap.get("heroname");
  }

}

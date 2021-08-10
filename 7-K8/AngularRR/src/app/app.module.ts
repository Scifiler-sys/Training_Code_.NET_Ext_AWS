import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import { AppComponent } from './app.component';
import { HeroListComponent } from './hero-list/hero-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { PokemonComponent } from './pokemon/pokemon.component';
import { HttpClientModule } from '@angular/common/http';
import { RestaurantComponent } from './restaurant/restaurant.component';
import { AuthGuard, AuthModule } from '@auth0/auth0-angular';
import { environment } from 'src/environments/environment';
import { AuthLoginComponent } from './auth-login/auth-login.component';

@NgModule({
  declarations: [ //This will hold the reference to other component this application will need
    AppComponent, 
    HeroListComponent,
    PokemonComponent,
    RestaurantComponent,
    AuthLoginComponent
  ],
  imports: [ //This is where we reference modules that we will need for this project
    BrowserModule,
    FormsModule,
    AuthModule.forRoot({
      domain: environment.domain,
      clientId: environment.clientId
    }),

    RouterModule.forRoot([
      {path: "superhero", component: HeroListComponent},
      {path: "pokemon", component: PokemonComponent, canActivate: [AuthGuard]},
      {path: "restaurant", component: RestaurantComponent, canActivate: [AuthGuard]},
      {path: "**", redirectTo:"superhero"}
    ]),
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule
  ],
  providers: [], //This is where you reference services
  bootstrap: [AppComponent] //This is first loaded component/code in the angular application
})
export class AppModule { }

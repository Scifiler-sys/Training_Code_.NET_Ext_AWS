import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-auth-login',
  templateUrl: './auth-login.component.html',
  styleUrls: ['./auth-login.component.css']
})
export class AuthLoginComponent implements OnInit {

  constructor(public auth:AuthService, @Inject(DOCUMENT) private document: Document) { }

  ngOnInit(): void {
  }

  login()
  {
    //Redirects the page to the Auth0 website to do the login for us
    this.auth.loginWithRedirect();
  }

  logout()
  {
    //Will use the document that was injected to redirect us to the same page as where we are
    this.auth.logout({returnTo: this.document.location.origin});
  }
}

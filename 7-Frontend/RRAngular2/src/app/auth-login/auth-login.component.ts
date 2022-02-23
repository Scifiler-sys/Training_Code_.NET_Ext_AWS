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
    this.auth.loginWithRedirect();
  }

  logout()
  {
    this.auth.logout({returnTo: this.document.location.origin});
  }

}

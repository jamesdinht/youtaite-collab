import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import * as auth0 from 'auth0-js';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  auth0 = new auth0.WebAuth({
    clientID: 'c6DwkGblBC8vr9lnLFPpJ5a79MeEkeuc',
    domain: 'jamesdinht.auth0.com',
    responseType: 'token id_token',
    audience: 'https://jamesdinht.auth0.com/userinfo',
    redirectUri: 'http://localhost:9000/callback',
    scope: 'openid'
  });

  constructor() { }

  public login(): void {
    this.auth0.authorize();
  }
}

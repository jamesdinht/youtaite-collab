import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import * as auth0 from 'auth0-js';
import { LogService } from 'src/app/shared/log.service';
import { Config } from 'src/app/auth/authconfig';

(window as any).global = window;

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  config = new Config();
  auth0 = new auth0.WebAuth({
    clientID: this.config.AUTH_CONFIG.CLIENT_ID,
    domain: this.config.AUTH_CONFIG.CLIENT_DOMAIN,
    responseType: this.config.AUTH_CONFIG.RESPONSETYPE,
    audience: this.config.AUTH_CONFIG.AUDIENCE,
    redirectUri: this.config.AUTH_CONFIG.REDIRECT,
    scope: this.config.AUTH_CONFIG.SCOPE
  });

  constructor(private router: Router, private logger: LogService) { }

  public login(): void {
    this.auth0.authorize();
  }

  public handleAuthentication(): void {
    this.auth0.parseHash((err, authResult) => {
      if (authResult && authResult.accessToken && authResult.idToken) {
        window.location.hash = '';
        this.setSession(authResult);
        this.router.navigate(['']);
      } else if (err) {
        this.router.navigate(['']);
        this.logger.logError(err, 'handleAuthentication');
      }
    });
  }

  private setSession(authResult): void {
     // Set the time that the Access Token will expire at
    const expiresAt = JSON.stringify((authResult.expiresIn * 1000) + new Date().getTime());
    localStorage.setItem('access_token', authResult.accessToken);
    localStorage.setItem('id_token', authResult.idToken);
    localStorage.setItem('expires_at', expiresAt);
  }

  public logout(): void {
    // Remove tokens and expiry time from localStorage
    localStorage.removeItem('access_token');
    localStorage.removeItem('id_token');
    localStorage.removeItem('expires_at');
    // Go back to the home route
    this.auth0.logout({
      returnTo: this.config.AUTH_CONFIG.RETURNTO,
      clientID: this.config.AUTH_CONFIG.CLIENT_ID,
      federated: true
    });
  }

  public isAuthenticated(): boolean {
    // Check whether the current time is past the Access Token's expiry time
    const expiresAt = JSON.parse(localStorage.getItem('expires_at') || '{}');
    return new Date().getTime() < expiresAt;
  }
}

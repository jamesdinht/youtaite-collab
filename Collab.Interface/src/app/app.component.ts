import { Component } from '@angular/core';
import { AuthService } from './auth/auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Youtaite Collab';

  constructor(public authService: AuthService) {
    authService.handleAuthentication();
    authService.scheduleRenewal();
  }
}

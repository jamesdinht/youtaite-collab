import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth/auth/auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  profile: any;

  constructor(public authService: AuthService) { }

  ngOnInit() {
    this.authService.getProfile((err, data) => {
      this.profile = data;
    });
  }

}

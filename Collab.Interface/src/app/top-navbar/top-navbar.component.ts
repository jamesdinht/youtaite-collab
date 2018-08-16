import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth/auth/auth.service';

@Component({
  selector: 'app-top-navbar',
  templateUrl: './top-navbar.component.html',
  styleUrls: ['./top-navbar.component.css']
})
export class TopNavbarComponent implements OnInit {

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }
}

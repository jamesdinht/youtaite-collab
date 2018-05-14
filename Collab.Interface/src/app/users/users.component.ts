import { Component, OnInit } from '@angular/core';
import { User } from './user';
import { UserService } from './user.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users: User[];

  constructor(private userService: UserService) { }

  getAllUsers() {
    return this.userService.getAllUsers().subscribe(result => this.users = result);
  }

  ngOnInit() {
    this.getAllUsers();
  }

}

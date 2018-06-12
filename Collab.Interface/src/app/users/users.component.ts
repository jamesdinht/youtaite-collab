import { Component, OnInit } from '@angular/core';
import { User } from '../models/user';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
  providers: [UserService]
})

export class UsersComponent implements OnInit {

  users: User[];
  selectedUser: User;
  operationSuccess: boolean;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.getAllUsers();
  }

  getAllUsers() {
    return this.userService.getAllUsers().subscribe(
      response => {
        this.users = response;
        this.operationSuccess = true;
      }
    );
  }

  getUserById(id: number) {
    return this.userService.getUserById(id).subscribe(
      response => {
        this.selectedUser = response;
        this.operationSuccess = true;
      }
    );
  }

  createUser(user: User) {
    return this.userService.createUser(user).subscribe(
      response => {
        this.users.push(response);
        this.selectedUser = response;
        this.operationSuccess = true;
      }
    );
  }

  updateUser(updatedUser: User) {
    return this.userService.updateUser(updatedUser).subscribe(
      response => {
        this.selectedUser = response;
        this.operationSuccess = true;
      }
    );
  }

  deleteUser(userToDelete: User) {
    return this.userService.deleteUser(userToDelete).subscribe(
      response => {
        this.users.findIndex(user => user.id === userToDelete.id);
      }
    );
  }
}

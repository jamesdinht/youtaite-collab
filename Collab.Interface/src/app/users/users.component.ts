import { Component, OnInit } from '@angular/core';
import { User } from '../models/user';
import { UserService } from './user.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
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
      },
      errorResponse => this.onError(errorResponse, 'getAllUsers'),
      () => this.onCompleted('getAllUsers')
    );
  }

  getUserById(id: number) {
    return this.userService.getUserById(id).subscribe(
      response => {
        this.selectedUser = response;
        this.operationSuccess = true;
      },
      errorResponse => this.onError(errorResponse, 'getUserById'),
      () => this.onCompleted('getUserById')
    );
  }

  createUser(user: User) {
    return this.userService.createUser(user).subscribe(
      response => {
        this.users.push(response);
        this.selectedUser = response;
        this.operationSuccess = true;
      },
      errorResponse => this.onError(errorResponse, 'createUser'),
      () => this.onCompleted('createUser')
    );
  }

  updateUser(updatedUser: User) {
    return this.userService.updateUser(updatedUser).subscribe(
      response => {
        this.selectedUser = response;
        this.operationSuccess = true;
      },
      errorResponse => this.onError(errorResponse, 'updateUser'),
      () => this.onCompleted('updateUser')
    );
  }

  deleteUser(userToDelete: User) {
    return this.userService.deleteUser(userToDelete).subscribe(
      response => {
        this.users.findIndex(user => user.id === userToDelete.id);
      },
      errorResponse => this.onError(errorResponse, 'deleteUser'),
      () => this.onCompleted('deleteUser')
    );
  }

  onError(errorResponse: any, operation: string) {
    this.operationSuccess = false;
    console.error(`${operation} errored with: ${errorResponse}`);
  }

  onCompleted(operation: string) {
    console.log(`${operation} completed`);
  }
}

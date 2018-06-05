import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  getAllUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>(environment.usersUrl)
      .pipe(
        catchError(this.handleError('getAllUsers', []))
      );
  }

  getUserById(id: number): Observable<User> {
    return this.httpClient.get<User>(`${environment.usersUrl}/${id}`, this.httpOptions)
    .pipe(
      catchError(this.handleError<User>(`getUserbyId id=${id}`))
    );
  }

  createUser(user: User): Observable<User> {
    return this.httpClient.post<User>(environment.usersUrl, user, this.httpOptions);
  }

  updateUser(updatedUser: User): Observable<User> {
    return this.httpClient.put<User>(`${environment.usersUrl}/${updatedUser.id}`, updatedUser, this.httpOptions)
      .pipe(
        catchError(this.handleError('updateUser', updatedUser))
      );
  }

  deleteUser(userToBeDeleted: User): Observable<User[]> {
    return this.httpClient.delete<User[]>(environment.usersUrl + userToBeDeleted.id, this.httpOptions);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // Log the error
      console.log(`${operation} error`);

      return of(result as T);
    };
  }
}

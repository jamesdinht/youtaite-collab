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

  getAllUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>(environment.usersUrl)
      .pipe(
        catchError(this.handleError('getAllUsers', []))
      );
  }

  getUserById(id: number): Observable<User> {
    return this.httpClient.get<User>(`${environment.usersUrl}/${id}`)
    .pipe(
      catchError(this.handleError<User>(`getUserbyId id=${id}`))
    );
  }

  createUser(user: User): Observable<User> {
    const body = JSON.stringify({ Name: User.name });
    return this.httpClient.post<User>(environment.usersUrl, body);
  }

  updateUser(updatedUser: User): Observable<User> {
    return this.httpClient.put<User>(`${environment.usersUrl}/${updatedUser.id}`, updatedUser);
  }

  deleteUser(userToBeDeleted: User): Observable<User[]> {
    return this.httpClient.delete<User[]>(environment.usersUrl + userToBeDeleted.id);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // Log the error
      console.log(`${operation} error`);

      return of(result as T);
    };
  }
}

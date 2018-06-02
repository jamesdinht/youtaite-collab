import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private client: HttpClient) { }

  getAllUsers(): Observable<User[]> {
    return this.client.get<User[]>(environment.usersUrl)
      .pipe(
        catchError(this.handleError('getAllUsers', []))
      );
  }

  getUserById(id: number): Observable<User> {
    return this.client.get<User>(environment.usersUrl + `/${id}`)
    .pipe(
      catchError(this.handleError<User>(`getUserbyId id=${id}`))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // Log the error
      console.log(`${operation} error`);

      return of(result as T);
    };
  }
}

import { Injectable, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { User } from 'src/app/models/user';
import { HttpService } from 'src/app/shared/http.service';

@Injectable({
  providedIn: 'root'
})

export class UserService extends HttpService {


  constructor(private http: HttpClient) {
    super(http, environment.usersUrl);
   }

  getAllUsers(): Observable<User[]> {
    return this.getAll<User>()
      .pipe(
        catchError(this.handleError<User[]>('getAllUsers', []))
      );
  }

  getUserById(id: number): Observable<User> {
    return this.getById<User>(id)
      .pipe(
        catchError(this.handleError<User>(`getUserbyId id=${id}`))
      );
  }

  createUser(user: User): Observable<User> {
    return this.create<User>(user)
      .pipe(
        catchError(this.handleError<User>(`createUser`, user))
      );
  }

  updateUser(updatedUser: User): Observable<User> {
    return this.update<User>(updatedUser)
      .pipe(
        catchError(this.handleError('updateUser', updatedUser))
      );
  }

  deleteUser(userToBeDeleted: User): Observable<User> {
    return this.delete<User>(userToBeDeleted)
      .pipe(
        catchError(this.handleError<User>(`deleteUser`, userToBeDeleted))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // Log the error
      console.log(`${operation} error`);
      console.error(`${error.name}: ${error.message}`);

      return of(result as T);
    };
  }
}

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

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  getAllUsers(): Observable<User[]> {
    return super.getAll<User>().pipe(
      catchError(this.handleError<User[]>('getAllUsers', []))
    );
  }

  getUserById(id: number): Observable<User> {
    return this.httpClient.get<User>(`${environment.usersUrl}/${id}`, this.httpOptions)
      .pipe(
        catchError(this.handleError<User>(`getUserbyId id=${id}`))
      );
  }

  createUser(user: User): Observable<User> {
    return this.httpClient.post<User>(environment.usersUrl, user, this.httpOptions)
      .pipe(
        catchError(this.handleError<User>(`createUser`, user))
      );
  }

  updateUser(updatedUser: User): Observable<User> {
    return this.httpClient.put<User>(`${environment.usersUrl}/${updatedUser.id}`, updatedUser, this.httpOptions)
      .pipe(
        catchError(this.handleError('updateUser', updatedUser))
      );
  }

  deleteUser(userToBeDeleted: User): Observable<User> {
    return this.httpClient.delete<User>(`${environment.usersUrl}/${userToBeDeleted.id}`, this.httpOptions)
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

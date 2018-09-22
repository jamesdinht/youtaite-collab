import { Injectable, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { User } from '../models/user';
import { HttpService } from '../shared/http.service';
import { LogService } from '../shared/log.service';

@Injectable({
  providedIn: 'root'
})

export class UserService extends HttpService {

  constructor(private http: HttpClient, private logService: LogService) {
    super(http, logService, environment.usersUrl);
   }

  public getAllUsers(): Observable<User[]> {
    return this.getAll<User>()
      .pipe(
        catchError(this.handleError<User[]>('getAllUsers', []))
      );
  }

  public getUserById(id: number): Observable<User> {
    return this.getById<User>(id)
      .pipe(
        catchError(this.handleError<User>(`getUserbyId id=${id}`))
      );
  }

  public getUserByEmail(email: string): Observable<User> {
    return this.http.get<User>(`${environment.usersUrl}/${email}`, this.httpOptions)
      .pipe(
        catchError(this.handleError<User>('getUserByEmail', null))
      );
  }

  public createUser(userToCreate: User): Observable<User> {
    return this.create<User>(userToCreate)
      .pipe(
        catchError(this.handleError<User>(`createUser`, userToCreate))
      );
  }

  public updateUser(updatedUser: User): Observable<User> {
    return this.update<User>(updatedUser)
      .pipe(
        catchError(this.handleError('updateUser', updatedUser))
      );
  }

  public deleteUser(userToBeDelete: User): Observable<User> {
    return this.delete<User>(userToBeDelete)
      .pipe(
        catchError(this.handleError<User>(`deleteUser`, userToBeDelete))
      );
  }
}

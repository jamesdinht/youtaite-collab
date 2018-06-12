import { Injectable, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { User } from 'src/app/models/user';
import { HttpService } from 'src/app/shared/http.service';
import { LogService } from 'src/app/shared/log.service';

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

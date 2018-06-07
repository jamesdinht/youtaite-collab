import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(protected httpClient: HttpClient, protected apiUrl: string) { }

  protected httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  get<T>(): Observable<T[]> {
    return this.httpClient.get<T[]>(this.apiUrl, this.httpOptions)
      .pipe(
        catchError(this.handleError<T[]>(this.get.name, []))
      );
  }

  getById<T>(id: number): Observable<T> {
    return this.httpClient.get<T>(this.apiUrl, this.httpOptions)
      .pipe(
        catchError(this.handleError<T>(this.getById.name))
      );
  }

  protected handleError<T>(operation = 'operation', result?: T) {
    return (error: Error): Observable<T> => {
      // Log error
      console.error(`${operation} error`);
      console.error(`${error.name}: ${error.message}`);

      return of(result as T);
    };
  }
}

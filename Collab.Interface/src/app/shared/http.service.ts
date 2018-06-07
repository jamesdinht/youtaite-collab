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

  getAll<T>(): Observable<T[]> {
    return this.httpClient.get<T[]>(this.apiUrl, this.httpOptions);
  }

  getById<T>(id: number): Observable<T> {
    return this.httpClient.get<T>(this.apiUrl, this.httpOptions);
  }
}

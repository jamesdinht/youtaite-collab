import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { BaseModel } from 'src/app/models/BaseModel';

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

  getAll<T extends BaseModel>(): Observable<T[]> {
    return this.httpClient.get<T[]>(this.apiUrl, this.httpOptions);
  }

  getById<T extends BaseModel>(id: number): Observable<T> {
    return this.httpClient.get<T>(`${this.apiUrl}/${id}`, this.httpOptions);
  }

  create<T extends BaseModel>(entity: T): Observable<T> {
    return this.httpClient.post<T>(this.apiUrl, entity, this.httpOptions);
  }

  update<T extends BaseModel>(updatedEntity: T): Observable<T> {
    return this.httpClient.put<T>(`${this.apiUrl}/${updatedEntity.id}`, updatedEntity, this.httpOptions);
  }

  delete<T extends BaseModel>(entityToDelete: T): Observable<T> {
    return this.httpClient.delete<T>(`${this.apiUrl}/${entityToDelete.id}`, this.httpOptions);
  }

  protected handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // Log the error
      console.log(`${operation} error`);
      console.error(`${error.name}: ${error.message}`);

      return of(result as T);
    };
  }
}

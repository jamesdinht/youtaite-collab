import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { BaseModel } from '../models/BaseModel';
import { LogService } from './log.service';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(protected httpClient: HttpClient, private logger: LogService, protected apiUrl: string) { }

  protected httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  protected getAll<T extends BaseModel>(): Observable<T[]> {
    return this.httpClient.get<T[]>(this.apiUrl, this.httpOptions);
  }

  protected getById<T extends BaseModel>(id: number): Observable<T> {
    return this.httpClient.get<T>(`${this.apiUrl}/${id}`, this.httpOptions);
  }

  protected create<T extends BaseModel>(entity: T): Observable<T> {
    return this.httpClient.post<T>(this.apiUrl, entity, this.httpOptions);
  }

  protected update<T extends BaseModel>(updatedEntity: T): Observable<T> {
    return this.httpClient.put<T>(`${this.apiUrl}/${updatedEntity.id}`, updatedEntity, this.httpOptions);
  }

  protected delete<T extends BaseModel>(entityToDelete: T): Observable<T> {
    return this.httpClient.delete<T>(`${this.apiUrl}/${entityToDelete.id}`, this.httpOptions);
  }

  protected handleError<T>(operation = 'operation', result?: T) {
    return (error: Error): Observable<T> => {
      // Log the error
      this.logger.logError(error, operation);

      return of(result as T);
    };
  }
}

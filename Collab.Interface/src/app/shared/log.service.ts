import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LogService {

  constructor() { }

  public logError(error: Error, operation: string) {
    console.error(`${operation} ${error.name}: ${error.message}`);
  }

  public logCompleted(operation: string) {
    console.log(`${operation} completed.`);
  }
}

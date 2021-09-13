import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LogService {

  private baseUrl: string = 'https://localhost:44373'

  constructor(private http: HttpClient) { }

  getSyncLogs(): Observable<any> {
    return this.http.get(`${this.baseUrl}/logs/sync`)
      .pipe(
        take(1),
        map(result => result)
      );
  }

  getDeleteLogs(): Observable<any> {
    return this.http.get(`${this.baseUrl}/logs/delete`)
      .pipe(
        take(1),
        map(result => result)
      );
  }
}

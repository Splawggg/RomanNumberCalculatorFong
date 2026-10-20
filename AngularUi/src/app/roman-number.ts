import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class RomanNumberService {
  private readonly apiUrl = 'https://localhost:7001'; // Anpassen!

  constructor(private http: HttpClient) { }

  isValid(roman: string): Observable<boolean> {
    return this.http.get<boolean>(
      `${this.apiUrl}/isValid`,
      { params: new HttpParams().set('roman', roman) }
    );
  }

  add(a: string, b: string): Observable<string> {
    const params = new HttpParams().set('a', a).set('b', b);
    return this.http.get<string>(`${this.apiUrl}/add`, { params });
  }

  divide(
    dividend: string,
    divisor: string
  ): Observable<{ quotient: string; remainder: string }> {
    const params = new HttpParams()
      .set('dividend', dividend)
      .set('divisor', divisor);

    return this.http.get<{ quotient: string; remainder: string }>(
      `${this.apiUrl}/div`, { params }
    );
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AuthData } from '../models/auth-data.model'; // Adjust the import based on your structure

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private mockDataUrl = 'assets/mock-data/auth.mock.json'; // Path to your mock data

  constructor(private http: HttpClient) { }

  // Method to get mock authentication data
  getAuthData(): Observable<AuthData[]> {
    return this.http.get<AuthData[]>(this.mockDataUrl).pipe(
      catchError(this.handleError<AuthData[]>('getAuthData', []))
    );
  }

  // Method to authenticate user
  authenticate(username: string, password: string): Observable<boolean> {
    return this.getAuthData().pipe(
      map(authData => {
        const user = authData.find(user => user.username === username && user.password === password);
        return user ? true : false;
      }),
      catchError(this.handleError<boolean>('authenticate', false))
    );
  }

  // Mock method to get current user
  getCurrentUser(): Observable<AuthData | null> {
    // In a real application, you would get the current user from a token or session
    return of(null); // Return null for now
  }

  // Handle errors
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(`${operation} failed: ${error.message}`); // Log to console
      return of(result as T); // Let the app keep running by returning an empty result
    };
  }
}

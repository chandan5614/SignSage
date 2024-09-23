import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { User } from '../models/user.model'; // Adjust the import based on your structure

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private mockDataUrl = 'assets/mock-data/user.mock.json'; // Path to your mock data

  constructor(private http: HttpClient) {}

  // Method to get mock user data
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.mockDataUrl).pipe(
      catchError(this.handleError<User[]>('getUsers', []))
    );
  }

  // Method to get user by ID
  getUserById(id: string): Observable<User | undefined> {
    return this.getUsers().pipe(
      map(users => users.find(user => user.id === id)),
      catchError(this.handleError<User | undefined>('getUserById'))
    );
  }

  // Method to add a new user
  addUser(userData: User): Observable<User> {
    // In a real application, you would send a POST request to the server
    return of(userData); // Return the user data as a mock response
  }

  // Method to update user details
  updateUser(userData: User): Observable<User> {
    // In a real application, you would send a PUT request to the server
    return of(userData); // Return the updated user data as a mock response
  }

  // Method to delete a user
  deleteUser(id: string): Observable<boolean> {
    // In a real application, you would send a DELETE request to the server
    return of(true); // Return true as a mock response indicating success
  }

  // Handle errors
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(`${operation} failed: ${error.message}`); // Log to console
      return of(result as T); // Let the app keep running by returning an empty result
    };
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Renewal } from '../models/renewal.model'; // Adjust the import based on your structure

@Injectable({
  providedIn: 'root'
})
export class RenewalService {
  private mockDataUrl = 'assets/mock-data/renewals.mock.json'; // Path to your mock data

  constructor(private http: HttpClient) { }

  // Method to get all renewals
  getRenewals(): Observable<Renewal[]> {
    return this.http.get<Renewal[]>(this.mockDataUrl).pipe(
      catchError(this.handleError<Renewal[]>('getRenewals', []))
    );
  }

  // Method to get a renewal by ID
  getRenewalById(id: string): Observable<Renewal | undefined> {
    return this.getRenewals().pipe(
      map(renewals => renewals.find(renewal => renewal.id === id)),
      catchError(this.handleError<Renewal | undefined>('getRenewalById'))
    );
  }

  // Method to create a new renewal
  createRenewal(renewal: Renewal): Observable<Renewal> {
    // This is a mock implementation, in a real app you would send a POST request
    return of(renewal); // Mocking creation by returning the same renewal
  }

  // Method to update a renewal
  updateRenewal(renewal: Renewal): Observable<Renewal> {
    // This is a mock implementation, in a real app you would send a PUT request
    return of(renewal); // Mocking update by returning the same renewal
  }

  // Method to delete a renewal
  deleteRenewal(id: string): Observable<boolean> {
    // This is a mock implementation, in a real app you would send a DELETE request
    return of(true); // Mocking deletion by returning true
  }

  // Handle errors
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(`${operation} failed: ${error.message}`); // Log to console
      return of(result as T); // Let the app keep running by returning an empty result
    };
  }
}

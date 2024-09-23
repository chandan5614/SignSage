import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Document } from '../models/document.model'; // Adjust the import based on your structure

@Injectable({
  providedIn: 'root'
})
export class DocumentService {
  private mockDataUrl = 'assets/mock-data/document.mock.json'; // Path to your mock data

  constructor(private http: HttpClient) {}

  // Method to get mock document data
  getDocuments(): Observable<Document[]> {
    return this.http.get<Document[]>(this.mockDataUrl).pipe(
      catchError(this.handleError<Document[]>('getDocuments', []))
    );
  }

  // Method to get document by ID
  getDocumentById(id: string): Observable<Document | undefined> {
    return this.getDocuments().pipe(
      map(documents => documents.find(document => document.id === id)),
      catchError(this.handleError<Document | undefined>('getDocumentById'))
    );
  }

  // Method to add a new document
  addDocument(documentData: Document): Observable<Document> {
    // In a real application, you would send a POST request to the server
    return of(documentData); // Return the document data as a mock response
  }

  // Method to update document details
  updateDocument(documentData: Document): Observable<Document> {
    // In a real application, you would send a PUT request to the server
    return of(documentData); // Return the updated document data as a mock response
  }

  // Method to delete a document
  deleteDocument(id: string): Observable<boolean> {
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

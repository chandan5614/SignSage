import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Template } from '../models/template.model'; // Adjust the import based on your structure

@Injectable({
  providedIn: 'root'
})
export class TemplateService {
  private mockDataUrl = 'assets/mock-data/templates.mock.json'; // Path to your mock data

  constructor(private http: HttpClient) {}

  // Method to get mock template data
  getTemplates(): Observable<Template[]> {
    return this.http.get<Template[]>(this.mockDataUrl).pipe(
      catchError(this.handleError<Template[]>('getTemplates', []))
    );
  }

  // Method to get a template by ID
  getTemplateById(id: string): Observable<Template | undefined> {
    return this.getTemplates().pipe(
      map(templates => templates.find(temp => temp.id === id)),
      catchError(this.handleError<Template | undefined>('getTemplateById'))
    );
  }

  // Method to create a new template
  createTemplate(newTemplate: Template): Observable<Template> {
    // In a real application, you'd send a POST request to the server
    return of(newTemplate); // Simulating a successful template creation
  }

  // Method to update a template
  updateTemplate(updatedTemplate: Template): Observable<Template> {
    // In a real application, you'd send a PUT request to the server
    return of(updatedTemplate); // Simulating a successful template update
  }

  // Method to delete a template by ID
  deleteTemplate(id: string): Observable<boolean> {
    // In a real application, you'd send a DELETE request to the server
    return of(true); // Simulating a successful deletion
  }

  // Handle errors
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(`${operation} failed: ${error.message}`); // Log to console
      return of(result as T); // Let the app keep running by returning an empty result
    };
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  jwtSecret = environment.jwtSecret;

  constructor(private http: HttpClient, private router: Router) {}

  login(credentials: { email: string, password: string }): Observable<any> {
    return this.http.post<any>('/api/auth/login', credentials).pipe(
      tap(response => {
        localStorage.setItem(this.jwtSecret, response.token);
      })
    );
  }

  logout(): void {
    localStorage.removeItem(this.jwtSecret);
    this.router.navigate(['/login']);
  }

  getToken(): string | null {
    return localStorage.getItem(this.jwtSecret);
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }
}

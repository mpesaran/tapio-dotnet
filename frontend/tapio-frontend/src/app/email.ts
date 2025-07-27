import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Email } from './models/email.model';

@Injectable({
  providedIn: 'root',
})
export class EmailService {
  private baseUrl = 'http://localhost:5089/api';

  constructor(private http: HttpClient) {}

  getEmailsByProjectId(projectId: string): Observable<Email[]> {
    return this.http.get<Email[]>(`${this.baseUrl}/emails/${projectId}`);
  }
}

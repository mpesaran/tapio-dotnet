import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Project } from './models/project.model';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  private baseUrl = 'http://localhost:5089/api/';

  constructor(private http: HttpClient) {}

  getUserProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(`${this.baseUrl}projects/user-projects`);
  }
}

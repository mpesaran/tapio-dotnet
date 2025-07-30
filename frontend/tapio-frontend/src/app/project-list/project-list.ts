// import { Component } from '@angular/core';
// import { ProjectService } from '../project';
// import { EmailService } from '../email';
// import { Project } from '../models/project.model';
// import { Email } from '../models/email.model';
// import { CommonModule } from '@angular/common';
// import { HttpClient } from '@angular/common/http';

// @Component({
//   selector: 'app-project-list',
//   standalone: true,
//   imports: [CommonModule],
//   templateUrl: './project-list.html',
//   styleUrl: './project-list.css'
// })
// export class ProjectListComponent {
//   projects: Project[] = [];
//   projectEmails: { [projectId: string]: Email[] } = {};
//   loadingEmails = false;
//   loadingProjects = false;
//   emailVisibility: { [projectId: string]: boolean } = {};

//   constructor(private projectService: ProjectService, private http: HttpClient) {}

//   fetchProjects() {
//     this.loadingProjects = !this.loadingProjects;
//     this.projectService.getUserProjects().subscribe({
//       next: (data) => {
//         this.projects = data;
//         this.loadingProjects = false;
//       },
//       error: (err) => {
//         console.error('Error fetching projects', err);
//         this.loadingProjects = false;
//       }
//     });
//   }
  
//   fetchEmails(projectId: string) : void{
//     const isVisible = this.emailVisibility[projectId];
//     this.emailVisibility[projectId] = !isVisible;
//     if (isVisible) return;
//     this.loadingEmails = true;
//     this.http.get<Email[]>(`http://localhost:5089/api/emails/${projectId}`)
//     .subscribe({
//       next: (emails: any) => {
//         this.projectEmails[projectId] = emails;
//         this.loadingEmails = false;
//       },
//       error: (err: any) => {
//         console.error(`Failed to fetch emails for project ${projectId}`, err);
//       }
//     });
//   }
// }

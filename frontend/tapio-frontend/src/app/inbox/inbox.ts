import { Component, OnInit } from '@angular/core';
import { Email } from '../models/email.model';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { EmailItem } from '../email-item/email-item';

@Component({
  selector: 'app-inbox',
  standalone: true,
  imports: [CommonModule, EmailItem],
  templateUrl: './inbox.html',
  styleUrl: './inbox.css'
})
export class Inbox implements OnInit{
  emails: Email[] = [];
  tappedEmails: Email[] = [];
  unreadEmails: Email[] = [];
  readEmails : Email[] = [];

  constructor(private http: HttpClient) {}
  ngOnInit() {
    this.fetchInbox()
  }

  fetchInbox() {
    this.http.get<Email[]>('http://localhost:5089/api/emails/${projectId}').subscribe({
      next: (emails) => {
        this.emails = emails;
        this.classifyEmails();
      },
      error: (err) => console.error('Failed to fetch emails', err)
    });
  }
  classifyEmails() {
    this.tappedEmails = this.emails.filter(e => e.isTapped);
    this.unreadEmails = this.emails.filter(e => !e.isRead && !e.isTapped);
    this.readEmails = this.emails.filter(e => e.isRead && !e.isTapped);
  }
  toggleTapped(email: Email) {
    const updated = { ...email, isTapped: !email.isTapped};
    this.http.put(`http://localhost:5089/api/emails/${email.id}`, updated).subscribe({
      next: () => {
        email.isTapped = !email.isTapped;
        this.classifyEmails();
      }
    })
  }
  markAsRead(email: Email) {
    if (email.isRead) return;
    const updated = { ...email, isRead: true};
    this.http.put(`http://localhost:5089/api/emails/${email.id}`, updated).subscribe({
      next: () => {
        email.isRead = true;
        this.classifyEmails()
      }
    })

  }

}

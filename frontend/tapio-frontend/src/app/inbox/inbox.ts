import { Component } from '@angular/core';
import { Email } from '../models/email.model';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-inbox',
  imports: [],
  templateUrl: './inbox.html',
  styleUrl: './inbox.css'
})
export class Inbox {
  emails: Email[] = [];
  tappedEmails: Email[] = [];
  unreadEmails: Email[] = [];
  readEmails : Email[] = [];

  constructor(private http: HttpClient) {}

}

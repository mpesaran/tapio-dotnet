import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Inbox } from './inbox/inbox';

@Component({
  standalone: true,
  selector: 'app-root',
  templateUrl: './app.html',
  imports: [Inbox, CommonModule]
})
export class App {



}

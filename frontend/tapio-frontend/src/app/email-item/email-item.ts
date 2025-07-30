import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Email } from '../models/email.model';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';


@Component({
  selector: 'app-email-item',
  imports: [CommonModule],
  templateUrl: './email-item.html',
  styleUrl: './email-item.css'
})
export class EmailItem {
  @Input() email!:Email;
  @Output() tapToggle = new EventEmitter<string>();
  @Output() showTapIn: boolean = true;
  @Output() read =  new EventEmitter<string>();

  constructor(private router: Router) {}

  onEmailClick() {
    if (!this.email.isRead) {
      this.read.emit(this.email.id);
    }
    this.router.navigate(['/email', this.email.id]);
  }
  
  onTapClick(event: MouseEvent) {
    event.stopPropagation();
    this.tapToggle.emit(this.email.id);
  }

  get formattedDate(): string {
    return new Date(this.email.date).toLocaleDateString('en-GB', {
      year: 'numeric',
      month: '2-digit',
      day: '2-digit'
    });
  }
}

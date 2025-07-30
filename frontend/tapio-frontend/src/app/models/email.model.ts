export interface Email {
  id: string;
  subject: string;
  from: string;
  body: string;
  isRead: boolean;
  isTapped: boolean;
  date: string;
}

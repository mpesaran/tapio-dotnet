import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmailItem } from './email-item';

describe('EmailItem', () => {
  let component: EmailItem;
  let fixture: ComponentFixture<EmailItem>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EmailItem]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmailItem);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

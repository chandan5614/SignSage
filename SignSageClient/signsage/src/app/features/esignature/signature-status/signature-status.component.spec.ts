import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignatureStatusComponent } from './signature-status.component';

describe('SignatureStatusComponent', () => {
  let component: SignatureStatusComponent;
  let fixture: ComponentFixture<SignatureStatusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SignatureStatusComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SignatureStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

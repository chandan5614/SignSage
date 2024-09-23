import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RenewalDetailComponent } from './renewal-detail.component';

describe('RenewalDetailComponent', () => {
  let component: RenewalDetailComponent;
  let fixture: ComponentFixture<RenewalDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RenewalDetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RenewalDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

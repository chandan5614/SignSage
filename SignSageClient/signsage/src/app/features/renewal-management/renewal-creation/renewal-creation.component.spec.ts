import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RenewalCreationComponent } from './renewal-creation.component';

describe('RenewalCreationComponent', () => {
  let component: RenewalCreationComponent;
  let fixture: ComponentFixture<RenewalCreationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RenewalCreationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RenewalCreationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

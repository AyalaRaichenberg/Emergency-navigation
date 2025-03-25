import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmergencyReportingComponent } from './emergency-reporting.component';

describe('EmergencyReportingComponent', () => {
  let component: EmergencyReportingComponent;
  let fixture: ComponentFixture<EmergencyReportingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EmergencyReportingComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmergencyReportingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

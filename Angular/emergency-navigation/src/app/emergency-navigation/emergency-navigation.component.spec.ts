import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmergencyNavigationComponent } from './emergency-navigation.component';

describe('EmergencyNavigationComponent', () => {
  let component: EmergencyNavigationComponent;
  let fixture: ComponentFixture<EmergencyNavigationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EmergencyNavigationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmergencyNavigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

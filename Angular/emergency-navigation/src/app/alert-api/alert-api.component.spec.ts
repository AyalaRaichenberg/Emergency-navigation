import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlertApiComponent } from './alert-api.component';

describe('AlertApiComponent', () => {
  let component: AlertApiComponent;
  let fixture: ComponentFixture<AlertApiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AlertApiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AlertApiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

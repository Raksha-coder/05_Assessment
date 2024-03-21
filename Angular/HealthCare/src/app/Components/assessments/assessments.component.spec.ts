import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssessmentsComponent } from './assessments.component';

describe('AssessmentsComponent', () => {
  let component: AssessmentsComponent;
  let fixture: ComponentFixture<AssessmentsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AssessmentsComponent]
    });
    fixture = TestBed.createComponent(AssessmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

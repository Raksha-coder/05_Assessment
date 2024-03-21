import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNewAssessmentComponent } from './add-new-assessment.component';

describe('AddNewAssessmentComponent', () => {
  let component: AddNewAssessmentComponent;
  let fixture: ComponentFixture<AddNewAssessmentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddNewAssessmentComponent]
    });
    fixture = TestBed.createComponent(AddNewAssessmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

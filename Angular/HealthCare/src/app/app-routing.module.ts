import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddNewAssessmentComponent } from './Components/assessments/add-new-assessment/add-new-assessment.component';
import { AssessmentsComponent } from './Components/assessments/assessments.component';
import { EditAssessmentComponent } from './Components/assessments/Edit-Assessment/edit-assessment/edit-assessment.component';
import { PatientComponent } from './PatientComponents/patient/patient.component';
import { AddAssessmentComponent } from './PatientPopUp/add-assessment/add-assessment.component';
import { ViewAssessmentComponent } from './PatientPopUp/view-assessment/view-assessment.component';

const routes: Routes = [
  {path: '', component:AssessmentsComponent},
  {path: 'addAssessments', component:AddNewAssessmentComponent},
  {path: 'editAssessment/:id', component:EditAssessmentComponent},
  {path: 'patients', component:PatientComponent},
  {path:'patientAddAssessment/:id',component:AddAssessmentComponent},
  {path:'viewPatientAssessent/:id',component:ViewAssessmentComponent},
  





];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

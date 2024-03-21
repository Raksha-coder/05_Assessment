import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddNewAssessmentComponent } from './Components/assessments/add-new-assessment/add-new-assessment.component';
import { AssessmentsComponent } from './Components/assessments/assessments.component';

const routes: Routes = [
  {path: '', component:AssessmentsComponent},
  {path: 'addAssessments', component:AddNewAssessmentComponent},
  {path: 'addAssessments/:id', component:AddNewAssessmentComponent}





];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

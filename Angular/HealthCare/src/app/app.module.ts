import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AssessmentsComponent } from './Components/assessments/assessments.component';
import { AddNewAssessmentComponent } from './Components/assessments/add-new-assessment/add-new-assessment.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


//////////////////
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatMenuModule} from '@angular/material/menu';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatBadgeModule} from '@angular/material/badge';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatCardModule} from '@angular/material/card';
import {MatSliderModule} from '@angular/material/slider';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSortModule} from '@angular/material/sort';
import { HttpClientModule } from '@angular/common/http';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatCommonModule, MatNativeDateModule} from '@angular/material/core';
import {MatRadioModule} from '@angular/material/radio';
import {MatSelectModule} from '@angular/material/select';
import {MatDialogModule} from '@angular/material/dialog';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { PopupComponent } from './Components/popup/popup.component';
import { EditAssessmentComponent } from './Components/assessments/Edit-Assessment/edit-assessment/edit-assessment.component';
import { PatientComponent } from './PatientComponents/patient/patient.component';
import { AddPatientComponent } from './PatientPopUp/add-patient/add-patient.component';
import { EditPatientComponent } from './PatientPopUp/edit-patient/edit-patient.component';
import { AddAssessmentComponent } from './PatientPopUp/add-assessment/add-assessment.component';
import { ViewAssessmentComponent } from './PatientPopUp/view-assessment/view-assessment.component';
import { ToastrModule } from 'ngx-toastr';
import { TimePipePipe } from './PatientPopUp/view-assessment/DatePipe/time-pipe.pipe';





@NgModule({
  declarations: [
    AppComponent,
    AssessmentsComponent,
    AddNewAssessmentComponent,
    PopupComponent,
    EditAssessmentComponent,
    PatientComponent,
    AddPatientComponent,
    EditPatientComponent,
    AddAssessmentComponent,
    ViewAssessmentComponent,
    TimePipePipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatToolbarModule,
    MatMenuModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatIconModule,
    MatBadgeModule,
    MatSidenavModule,
    MatListModule,
    MatCheckboxModule,
    MatCardModule,
    MatSliderModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    HttpClientModule,
    MatDatepickerModule,
    MatCommonModule,
    MatRadioModule,
    MatSelectModule,
    MatNativeDateModule,
    MatDialogModule,
    MatSnackBarModule,
    MatProgressSpinnerModule,
    MatFormFieldModule, 
    MatInputModule,
    MatAutocompleteModule,
    ToastrModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

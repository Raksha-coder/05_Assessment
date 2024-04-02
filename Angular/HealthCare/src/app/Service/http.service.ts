import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }

  private url = 'https://localhost:7292/api/Assessment';
  private patientUrl = "https://localhost:7292/api/Patient";

  QueryAssismentNames(): Observable<any> {
    return this.http.get(`${this.url}/Assessmentnames`);
  }

  QueryPatients(): Observable<any> {
    return this.http.get(`${this.patientUrl}/Patients`);
  };


  QueryPatientById(Id: any): Observable<any> {
    return this.http.get(`${this.patientUrl}/Patient/id?id=${Id}`);
  };

  //get assessment along with questions
  QueryAssessmentQuestion(_assessmentId: any): Observable<any> {
    return this.http.get(`${this.url}/AssessmentnamesById?id=${_assessmentId}`);
  }

  QueryPatientAssessmentViewById(id: any): Observable<any> {
    return this.http.get(`${this.patientUrl}/PatientAssessmentView/id?_id=${id}`);
  };


  CommandAssessmentQuestion(assessmentQuestions: any): Observable<any> {
    return this.http.post(`${this.url}/AssismentQuestions`, assessmentQuestions);
  }

  CommandPatient(_patient: any): Observable<any> {
    return this.http.post(`${this.patientUrl}/addPatient`, _patient);
  };


  CommandPatientToAssessment(patientToAssessment: any): Observable<any> {
    return this.http.post(`${this.patientUrl}/PatientToAssessment`, patientToAssessment);
  }


  CommandPatientAssessmentView(patientToAssessmentView: any): Observable<any> {
    return this.http.post(`${this.patientUrl}/PatientAssessmentView`, patientToAssessmentView);
  };


  putPatient(_patientdata: any): Observable<any> {
    return this.http.put(`${this.patientUrl}/id`, _patientdata);
  }


}

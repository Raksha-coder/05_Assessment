import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }

  private url ='https://localhost:7292/api/Assessment';

  
  getAssismentNames():Observable<any> {
    return this.http.get(`${this.url}/Assessmentnames`);
  }

  postAssessmentQuestion(data:any):Observable<any> {
    return this.http.post(`${this.url}/AssismentQuestions`, data);
  }
}

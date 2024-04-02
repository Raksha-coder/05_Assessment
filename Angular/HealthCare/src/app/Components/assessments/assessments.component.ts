import { Component } from '@angular/core';
import { HttpService } from 'src/app/Service/http.service';

@Component({
  selector: 'app-assessments',
  templateUrl: './assessments.component.html',
  styleUrls: ['./assessments.component.css']
})
export class AssessmentsComponent {

  constructor(private service:HttpService){}

  AssessmentNames:any[] = [];

  ngOnInit(){
      this.service.QueryAssismentNames().subscribe(
        (response) =>{
            this.AssessmentNames = response.response;
          console.log(response.response);
            
        },
        (error)=>{
          console.log(error);
          
        }
      )
  }

}

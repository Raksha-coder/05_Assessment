import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { HttpService } from 'src/app/Service/http.service';

@Component({
  selector: 'app-view-assessment',
  templateUrl: './view-assessment.component.html',
  styleUrls: ['./view-assessment.component.css']
})
export class ViewAssessmentComponent {
    constructor(private service : HttpService,
    private route:ActivatedRoute){}
    private routeSub:Subscription | undefined;
    patientid:any;
    patientName:any[] = [];
    patientQuestion:any[] = [];
    patientdetails:any[]=[];
    ngOnInit(){

      //get patient id from route 
    this.routeSub = this.route.params.subscribe(params =>{
      console.log(params['id']);
      if(params['id'] > 0){
          this.patientid = params['id'];
      }

    });

  
     //get patient name
    
      this.service.QueryPatientById(this.patientid).subscribe(
        (response)=>{
          // console.log(response);
            this.patientdetails = response.response;
        },
        (err)=>{
          console.log(err);
          
        }
      )


    //send patient id with selected assessment id
      this.service.QueryPatientAssessmentViewById(Number(this.patientid)).subscribe(
        (response)=>{
          this.patientName = response.patientAssessement; 
        },
        (error)=>{
          console.log(error);
          
        }
      );



    }



   
value:any;
    onDropdownChange(optionId: any){
       this.value = optionId;
       console.log(optionId);

       
      let data = 
      {
        "id": this.patientid,
        "patient_Assessment_Id": optionId
      };
    


    //all the question according to patient and assessment id
    this.service.CommandPatientAssessmentView(data).subscribe(
      (response)=>{
        console.log(response);
        this.patientQuestion = response.patientQuestionResponse;
        console.log( this.patientQuestion);
        
      },
      (error)=>{
        console.log(error);
        
      }
    )
       
        
    }

}

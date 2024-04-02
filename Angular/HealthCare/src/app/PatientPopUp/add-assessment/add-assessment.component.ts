import { getLocaleFirstDayOfWeek } from '@angular/common';
import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { HttpService } from 'src/app/Service/http.service';

@Component({
  selector: 'app-add-assessment',
  templateUrl: './add-assessment.component.html',
  styleUrls: ['./add-assessment.component.css']
})
export class AddAssessmentComponent {
  AssessmentNames:any[] = [];
  AssessmentForm!:FormGroup;
  AssessmentQuestionForm!:FormGroup;

  constructor(private service:HttpService,private fb:FormBuilder,
    private route:ActivatedRoute,private toastr: ToastrService,  private router: Router){}
    
  patientdetails:any[]=[];


  private routeSub:Subscription | undefined;
  patientid:any;
  responsetype:any;
  ngOnInit(){
     this.service.QueryAssismentNames().subscribe(
      (Response)=>{
          this.AssessmentNames = Response.response;
      },(error)=>{
          console.log(error);
          
      }
     );


     this.AssessmentForm = this.fb.group(
      {
        assessmentName:['']
      }
     );

     //second form
     this.AssessmentQuestionForm = this.fb.group(
      {
        responsearray: this.fb.array([]) 
      }
     );

 


     

     
  //get patient id from route 
    this.routeSub = this.route.params.subscribe(params =>{
      // console.log(params['id']);
      if(params['id'] > 0){
          this.patientid = params['id'];
      }

    });


 //get patient name
    
 this.service.QueryPatientById(this.patientid).subscribe(
  (response)=>{
  
   this.patientdetails = response.response;
  },
  (err)=>{
    console.log(err);
    
  }
)



  }

  get responseArray() {
    return this.AssessmentQuestionForm.get('responsearray') as FormArray;
  }




  allQuestion:any[]=[];
  saveButtonDisplay = false;
  Submit(){
     console.log(this.AssessmentForm.value.assessmentName);
     console.log(this.AssessmentForm.value.assessmentName.id);  //assessment 2 ki id 


     while (this.responseArray.length !== 0) {
      this.responseArray.removeAt(0);
  }

    this.service.QueryAssessmentQuestion(this.AssessmentForm.value.assessmentName.id).subscribe(
      (res)=>{
        console.log(res);
        this.saveButtonDisplay = true;
        this.allQuestion = res.response[0].assementsQue;
        console.log(this.allQuestion);  //got the questions

        this.allQuestion.forEach(question => {
          const group = this.fb.group({
            questionid:[question.id],
            response: ['']
          });
         this.responseArray.push(group);
        });

        
      },(error)=>{
        console.log(error);
        
      }
    )

  }


  //second form

  onSubmitResponse() {
   



    console.log(this.AssessmentQuestionForm.value.responsearray);
    let patientQuestiondata = {
      "patientId": Number(this.patientid),
      "assessmentId": this.AssessmentForm.value.assessmentName.id,
      "assListQue": this.AssessmentQuestionForm.value.responsearray.map((question:any)=>(
        {
          "question_Id": question.questionid,
          "response": question.response
        }
      ))
     };

     console.log(patientQuestiondata);
     

    this.service.CommandPatientToAssessment(patientQuestiondata).subscribe(
      (res)=>{
        console.log(res);
        this.toastr.success('successfully added Assessment');
        this.router.navigate(['/patients']);
      },
      (err)=>{
        console.log(err);
        
      }
    );
  }




}

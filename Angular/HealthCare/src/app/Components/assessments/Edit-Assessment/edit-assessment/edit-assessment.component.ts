import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { HttpService } from 'src/app/Service/http.service';

@Component({
  selector: 'app-edit-assessment',
  templateUrl: './edit-assessment.component.html',
  styleUrls: ['./edit-assessment.component.css']
})
export class EditAssessmentComponent {

  constructor(private fb:FormBuilder,private service:HttpService,
    private route:ActivatedRoute,
    private toastr: ToastrService,
    private router: Router){}
 
  responseType:any = ["TEXT","TEXTAREA","RADIO","DATE"];
  //get assessment by id 
  private routeSub:Subscription | undefined;
  assessmentId:number = 0;
  assessments:any[]=[];
  assessmentWithQuestion:any[]=[];
  EditAssessmentForm!:FormGroup;

    ngOnInit(){

      //get id from route = assessment id
      this.routeSub = this.route.params.subscribe(params =>{
        console.log(params['id']);
        if(params['id'] > 0){
            this.assessmentId = params['id'];
        }

      });


       //get assessment with questions
      this.service.QueryAssessmentQuestion(this.assessmentId).subscribe(
        (res)=>{
          
          this.assessments = res.response[0].name;
          this.assessmentWithQuestion = res.response[0].assementsQue;


         
         //displaying all questions  
          this.assessmentWithQuestion.forEach(question => {
            const group = this.fb.group({
              questionsid: [question.id],
              response_Type: [''],
              isRequired: true,
              ques:[question.questions],
            });
          this.getQuestion.push(group);
          });

        },
        (error)=>{
          console.log(error);
          
        }
      );


        //form
        this.EditAssessmentForm = this.fb.group(
          {
            name: [''],  
            questions: this.fb.array([])   //push the data here 
          }
        );


    }



    get getQuestion(){
      return this.EditAssessmentForm.get("questions") as FormArray;
    }







    // questionArray!:FormArray;
    // pushArray(){
    //   this.questionArray = this.EditAssessmentForm.get("questions") as FormArray;  //empty array
    //   //add form to this array: address ke under mai
    //   this.questionArray.push(this.fb.group(
    //     {
    //       questions: [''],
    //       response_Type: [''],
    //       isRequired: true,
    //       responses:this.fb.array([])
    //     }
    //   ));
    // };


    //for drop down responses = switch case
    switch(event:any,i:any){
      const control = (this.EditAssessmentForm.get('questions') as FormArray).at(i).get('response_Type');
      control?.setValue(event);
    }


  
  
    onSubmit(){

      const data = {
        assDto: {
            updateId: Number(this.assessmentId),
            name: this.EditAssessmentForm.value.name,
            isScorable: 1 
        },
        assListQue: this.EditAssessmentForm.value.questions.map((question:any) => ({
            id:Number(question.questionsid),
            questions: question.ques,
            response_Type: question.response_Type,
            isRequired: question.isRequired,
            assessmentId: 0 ,
        }))
    };

    // console.log(data);
    


    this.service.CommandAssessmentQuestion(data).subscribe(
      (res)=>{
          console.log(res);
          this.toastr.success('successfully Updated Assessment');
          this.router.navigate(['/']);
          
      },
      (err)=>{
        console.log(err);
        
      })

    




}
}

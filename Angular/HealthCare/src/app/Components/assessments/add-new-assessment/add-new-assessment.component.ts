import { Component } from '@angular/core';
import { PopupComponent } from '../../popup/popup.component';
import { MatDialog } from '@angular/material/dialog';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { HttpService } from 'src/app/Service/http.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-new-assessment',
  templateUrl: './add-new-assessment.component.html',
  styleUrls: ['./add-new-assessment.component.css']
})
export class AddNewAssessmentComponent {
  constructor(private fb: FormBuilder,private dialog:MatDialog,
    private service:HttpService,
    private route:ActivatedRoute,
    private toastr: ToastrService,
    private router: Router){}

  responseType = ["TEXT","TEXTAREA","DATE","RADIO"];
  form!: FormGroup;
  questionArray!:FormArray;


  //dialog
    ques:any;
  Openpopup(){
     var _popup =  this.dialog.open(PopupComponent,{
        width:'60%',
        height:'280px',
        enterAnimationDuration:'1000ms',
        exitAnimationDuration:'1000ms',
      });

      _popup.afterClosed().subscribe(items =>{
        console.log(items);   //here i am getting question
           this.ques = items;
           if(this.ques != ''){
            this.pushArray();

           };
            
      });
  }

  private routeSub:Subscription | undefined;

  editid:number = 0;
  ngOnInit() {
    this.form = this.fb.group({  
      name: [''],  
      questions: this.fb.array([]) 
    });


    //edit 
    this.routeSub = this.route.params.subscribe(params =>{
      console.log(params['id']);
      if(params['id'] > 0){
          this.editid = params['id'];
      }

    });

  }


  get getQuestion(){
    return this.form.get("questions") as FormArray;
}


addassis(){
            //first open the pop up then add question html
           this.Openpopup();
      
}


pushArray(){
  this.questionArray = this.form.get("questions") as FormArray;  //empty array
  //add form to this array: address ke under mai
  this.questionArray.push(this.fb.group(
    {
      questions: [this.ques],
      response_Type: [''],
      isRequired: true,
    }
  ));
}

//on submitting form
onSubmit() {
  //console.log(this.form.value);
  console.log(this.editid);
  
  const data = {
    assDto: {
        updateId: this.editid,
        name: this.form.value.name,
        isScorable: 1 
    },
    assListQue: this.form.value.questions.map((question:any) => ({
        questions: question.questions,
        response_Type: question.response_Type,
        isRequired: question.isRequired,
        assessmentId: 0 
    }))
};



  this.service.CommandAssessmentQuestion(data).subscribe(
    (res)=>{
        console.log(res);
        this.toastr.success('successfully added Assessment');
        this.router.navigate(['/']);
        
    },
    (err)=>{
      console.log(err);
      
    })

  
}








}

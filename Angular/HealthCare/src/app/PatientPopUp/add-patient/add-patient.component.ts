import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpService } from 'src/app/Service/http.service';

@Component({
  selector: 'app-add-patient',
  templateUrl: './add-patient.component.html',
  styleUrls: ['./add-patient.component.css']
})
export class AddPatientComponent {
      //

      constructor(private rf:MatDialogRef<AddPatientComponent>,
        @Inject(MAT_DIALOG_DATA) public data:any,
        private fb:FormBuilder,
        private api:HttpService,private toastr: ToastrService,
        private router: Router){}
    

      addPatientform!:FormGroup;  
      ngOnInit(){
    
        this.addPatientform = this.fb.group(
          { 
              firstname:[''],
              lastname:[''] ,
              dob: [''],
          }
        );
      }
    
      closepopup(){
        this.rf.close('Closed Using Function');
      }
    
      savePatient(){
          console.log(this.addPatientform.value);
          let formdata = {
            "firstname": this.addPatientform.value.firstname,
            "lastname": this.addPatientform.value.lastname,
            "dob": this.addPatientform.value.dob
          }


          this.api.CommandPatient(formdata).subscribe(
            (res)=>{
              console.log(res);
              this.toastr.success('success added Patient');
         
              this.closepopup();
            },
            (error)=>{
              console.log(error);
              
            }
          )
    
          
      }
      

      
}

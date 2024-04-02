import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { HttpService } from 'src/app/Service/http.service';

@Component({
  selector: 'app-edit-patient',
  templateUrl: './edit-patient.component.html',
  styleUrls: ['./edit-patient.component.css']
})
export class EditPatientComponent {
  constructor(private rf:MatDialogRef<EditPatientComponent>,
    @Inject(MAT_DIALOG_DATA) public data:any,   //i have id here
    private fb:FormBuilder,
    private api:HttpService,private toastr: ToastrService){}


  editPatientform!:FormGroup;  
  Patientid:any;
  PatientDataOfId:any;
  ngOnInit(){
    //assign patientid
    this.Patientid = this.data.EditId;
    if(this.Patientid > 0){
      
      this.setPatientdata(this.Patientid);
  }


    this.editPatientform = this.fb.group(
      { 
          firstname:[''],
          lastname:[''] ,
          dob: [''],
      }
    );
  }



  setPatientdata(_id:any){
    this.api.QueryPatientById(_id).subscribe(
      (res)=>{
        this.PatientDataOfId = res.response;
        console.log( this.PatientDataOfId[0]);
        
        this.editPatientform.setValue(
          {
            firstname:this.PatientDataOfId[0].firstname,
            lastname:this.PatientDataOfId[0].lastname,
            dob:this.PatientDataOfId[0].dob,
            });
        
      },
      (error)=>{
        console.log(error);
        
      }
    )
  }


  closepopup(){
    this.rf.close('Closed Using Function');
  }




  savePatient(){
      console.log(this.editPatientform.value);
      let formdata = {
        "id": this.Patientid,
        "firstname": this.editPatientform.value.firstname,
        "lastname": this.editPatientform.value.lastname,
        "dob": this.editPatientform.value.dob
      }

      this.api.putPatient(formdata).subscribe(
        (res)=>{
          console.log(res);
          this.closepopup();
          this.toastr.success('success updated Patient');
        },
        (error)=>{
          console.log(error);
          
        }
      )

      
  }
  
}

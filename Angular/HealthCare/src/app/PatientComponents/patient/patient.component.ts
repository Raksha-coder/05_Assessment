import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { AddPatientComponent } from 'src/app/PatientPopUp/add-patient/add-patient.component';
import { EditPatientComponent } from 'src/app/PatientPopUp/edit-patient/edit-patient.component';
import { HttpService } from 'src/app/Service/http.service';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent {
  constructor(private api:HttpService,private dialog:MatDialog){}
  patients:any[]=[];
  Source:any;
  displayColumn:string[] = ['Id','FName','LName','DOB','ACTION'];
  //pagination
  @ViewChild(MatPaginator)
  pagination !: MatPaginator;

  //sorting
  @ViewChild(MatSort)
  sort !: MatSort; 


  ngOnInit(){
     this.GetAllPatients();
  }


  GetAllPatients(){   //get all patient
      this.api.QueryPatients().subscribe(
      (res)=>{
          this.patients = res.response;
          this.Source = new MatTableDataSource(this.patients);
        
          
          //pagination
          this.Source.paginator = this.pagination;  //by default 
          //sorting
          this.Source.sort = this.sort;
  
      },
      (error)=>{
        console.log(error);
        
      }
      )
  }

  edit(getid:any){
        this.OpenEditPopup(getid);
  }


  OpenEditPopup(id:any){
    var _popup =  this.dialog.open(EditPatientComponent,{
       width:'60%',
       height:'400px',
       enterAnimationDuration:'1000ms',
       exitAnimationDuration:'1000ms',
       data:{
        EditId :id
       }
     });

     _popup.afterClosed().subscribe(items =>{
       console.log(items);   //check this
       this.GetAllPatients();  //load Patient  //check this
       
     });
 }













  addpatient(){
    this.Openpopup();
  }
  //dialog
  Openpopup(){
     var _popup =  this.dialog.open(AddPatientComponent,{
        width:'60%',
        height:'400px',
        enterAnimationDuration:'1000ms',
        exitAnimationDuration:'1000ms',
        data:{}
      });

      _popup.afterClosed().subscribe(items =>{
        console.log(items);
        this.GetAllPatients();  //load Patient  //check this
        
      });
  }


 

}

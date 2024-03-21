import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-popup',
  templateUrl: './popup.component.html',
  styleUrls: ['./popup.component.css']
})
export class PopupComponent {

  constructor(private rf:MatDialogRef<PopupComponent>,private fb:FormBuilder){}

  questionName!:FormGroup;


  ngOnInit(){
    this.questionName = this.fb.group({
      name :['']
    })
  }

  closepopup(){
    this.rf.close(this.questionName?.get('name')?.value);
  }
}

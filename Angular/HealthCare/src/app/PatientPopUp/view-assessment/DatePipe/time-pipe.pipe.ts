import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'timePipe'
})
export class TimePipePipe implements PipeTransform {


  transform(value: string | Date): string {
    if (!value) return '';

    //check the entered value is of type string or date 
    //it it is string then convert it into date else date hi le lo
    const date = typeof value === 'string' ? new Date(value) : value;

    //get hours from the value
    const hours = date.getHours();

    //if hours is greater than 12 , it will be PM or else AM
    const amPm = hours >= 12 ? 'PM' : 'AM';

    //I want to sow 13 as 1 and so on 
    const formattedHours = hours % 12 || 12;
    //13 %12  = 1;
    //14%12  = 2 and so on....


    //i want only 2 digit of minute so that's why i have used Padding
    const minutes = date.getMinutes().toString().padStart(2, '0');  

    return `${formattedHours}:${minutes} ${amPm}`;
  }

}

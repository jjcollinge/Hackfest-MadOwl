import { Component, OnInit } from '@angular/core';
import { Classroom } from './classroom';
import { ClassroomService } from './classroom.service'
import './rxjs-operators';

@Component({
  selector: 'my-app',
  templateUrl: './app/app.component.html',
   styleUrls: ['app/app.component.css'],
  providers: [
    ClassroomService
  ]
})
export class AppComponent implements OnInit { 
    public classroom: Classroom;
    public errorMessage: string;

    constructor(
        private _classroomService: ClassroomService) {
    }
    
    ngOnInit() {
      // HACK: hardcoded to read only first entry
        // this._classroomService.getClassroom(0)
        //    .then(classroom => this.classroom = classroom);

        this._classroomService.getClassrooms().subscribe(
          classroom => this.classroom = classroom,
          error => this.errorMessage = <any>error);
        
    }
}

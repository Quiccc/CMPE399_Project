import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { AllTasks } from '../task-interface';
import {DialogService} from 'primeng/dynamicdialog';
import {DynamicDialogRef} from 'primeng/dynamicdialog';

@Component({
  selector: 'app-all-tasks',
  templateUrl: './all-tasks.component.html',
  animations: [
    trigger('rowExpansionTrigger', [
        state('void', style({
            transform: 'translateX(-10%)',
            opacity: 0
        })),
        state('active', style({
            transform: 'translateX(0)',
            opacity: 1
        })),
        transition('* <=> *', animate('400ms cubic-bezier(0.86, 0, 0.07, 1)'))
    ])
],
  providers:[DialogService]
})
export class AllTasksComponent {

  tasks: AllTasks[];
  ref: DynamicDialogRef;
  constructor(private http: HttpClient, public DialogService: DialogService) {
    this.http.get<AllTasks[]>('https://localhost:44394/api/tasks/get-tasks').toPromise().then(data => {
      this.tasks = data;
      console.log(this.tasks);
    });
  }

  editTask(){
     this.ref = this.DialogService.open(AllTasksComponent,{

     });
  }

  ngOnDestroy(){
    if(this.ref){
      this.ref.close();
    }
  }
}



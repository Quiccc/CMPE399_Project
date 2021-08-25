import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tasks',
  templateUrl: './task.component.html'
})
export class TaskComponent {

  tasks: allTasks[];

  constructor(private router: Router, private http: HttpClient) {
    this.http.get<allTasks[]>("https://localhost:44394/tasks").toPromise().then(data => {
      this.tasks = data;
      console.log(this.tasks);
    });
  }
}

interface allTasks {
    taskId: bigint;
    taskName: string;
    deadline: string;
    assignedUsers: any[];
}


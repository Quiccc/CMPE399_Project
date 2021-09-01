import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { trigger, state, style, transition, animate } from '@angular/animations';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
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
]
})
export class UsersComponent{

  users: AllUsers[];

  constructor(private http: HttpClient) {
    this.http.get<AllUsers[]>('https://localhost:44394/api/users/get-users').toPromise().then(data => {
      this.users = data;
      console.log(this.users);
    });
  }

}

interface AllUsers {
  userId: bigint;
  userFirstName: string;
  userLastName: string;
  userTasks: any[];
}

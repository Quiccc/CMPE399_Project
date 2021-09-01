import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MenubarModule } from 'primeng/menubar';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { PasswordModule } from 'primeng/password';
import { TableModule } from 'primeng/table';
import { DynamicDialogModule } from 'primeng/dynamicdialog';


import { AppComponent } from './app.component';
import { LoginComponent } from './api-auth/login/login.component';
import { AuthInterceptorService } from './api-auth/auth-interceptor.service';
import { HomeComponent } from './home/home.component';
import { MenubarComponent } from './menubar/menubar.component';
import { AllTasksComponent } from './tasks/all-tasks/all-tasks.component';
import { UserTasksComponent } from './tasks/user-tasks/user-tasks.component';
import { EditTaskComponent } from './tasks/edit-task/edit-task.component';
import { UsersComponent } from './users/users.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    UserTasksComponent,
    AllTasksComponent,
    EditTaskComponent,
    MenubarComponent,
    UsersComponent
   ],
  imports: [
    TableModule,
    PasswordModule,
    MenubarModule,
    InputTextModule,
    ButtonModule,
    DynamicDialogModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'alltasks', component: AllTasksComponent },
      { path: 'mytasks', component: UserTasksComponent },
      { path: 'login', component: LoginComponent },
      { path: 'users', component: UsersComponent }
    ])
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  invalidLogin: boolean;

  constructor(private router: Router, private http: HttpClient) { }

  loginAsync(form: NgForm){
    const credentials = {
      'username': form.value.username,
      'password': form.value.password
    }

    this.http.post("https://localhost:44394/api/auth/login", credentials)
    .subscribe(response => {
      const message = (<any>response).message;
      if (message == "Success") {
        const token = ((<any>response).data).token;
        console.log(token);
        localStorage.setItem("jwt", token);
        this.invalidLogin = false;
        this.router.navigate([""]);
      }
      else
        this.invalidLogin = true;
    }, err => {
      this.invalidLogin = true;
    })
  }
}

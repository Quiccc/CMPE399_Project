import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import jwt_decode from 'jwt-decode';

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
})
export class LoginComponent {
  invalidLogin: boolean;
  username: string;
  password: string;

  constructor(private router: Router, private http: HttpClient) {}

  loginAsync(form: NgForm) {
    const credentials = {
      username: this.username,
      password: this.password,
    };

    this.http
      .post("https://localhost:44394/api/auth/login", credentials)
      .subscribe(
        (response) => {
          const message = (<any>response).message;
          if (message == "Success") {
            const token = (<any>response).data.token;
            localStorage.setItem("jwt", token);
            localStorage.setItem("role",(<any>jwt_decode(token)).role);
            this.invalidLogin = false;
            this.router.navigate([""]);
          } else this.invalidLogin = true;
        },
        (err) => {
          this.invalidLogin = true;
        }
      );
  }
}

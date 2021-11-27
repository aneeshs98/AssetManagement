import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from "../shared/user";
import { AuthService } from '../shared/auth.service';
import{JwtResponce}from "../shared/jwtrespone"


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  //declare variables
  loginForm!: FormGroup;
  isSubmitted = false;
  loginUser: User = new User;
  error = '';
  jwtResponse:any=new JwtResponce();
  constructor(private formbuilder: FormBuilder,
    private router: Router,public authService:AuthService
  ) { }

  ngOnInit(): void {
    this.loginForm = this.formbuilder.group(
      {
        UserName: ['', [Validators.required, Validators.minLength(3)]],
        Userpassword: ['', [Validators.required]],
      }
    );
  }


  //get controls

  get formControls() {
    return this.loginForm.controls;
  }

  //login verify credentials

  LoginCredentials() {

    //console.log(this.loginForm.value);
    this.isSubmitted = true;

    // invalid

    if (this.loginForm.invalid)
      return;



    //valid
    if (this.loginForm.valid) {

//calling method from Authservice 
      //calling token generation api

      this.authService.getTokenByPassword(this.loginForm.value).subscribe
      (data=>
        {
          console.log(data);
          this.jwtResponse=data;
          localStorage.setItem("token",data.token);// adding token to the local storage
          sessionStorage.setItem("token",data.token);
          //check the role
          if(data.RoleId===1)
              {
                //logged as admin
                console.log("admin");

                localStorage.setItem("username",data.UserName);
                
             
                sessionStorage.setItem("username",data.UserName);
                
              localStorage.setItem("Access_Role",data.RoleId.toString());
              //based on role redirect out application
                this.router.navigateByUrl("/admin");
              }
              else if(data.RoleId===2){
                console.log("manager")
                localStorage.setItem("username",data.UserName);
                sessionStorage.setItem("username",data.UserName);
                localStorage.setItem("Access_Role",data.RoleId.toString());
                //based on role redirect out application
                this.router.navigateByUrl("/manager");
              }
              else if(data.RoleId===3){
                console.log("user");
                localStorage.setItem("username",data.UserName);
                sessionStorage.setItem("username",data.UserName);
                localStorage.setItem("Access_Role",data.RoleId.toString());
                //based on role redirect out application
                this.router.navigateByUrl("/user");
              }
              else{
                this.error="Sorry .. invalid authorization"
              }
            },
            
        error=>
        {
          this.error="invalid"
        }
        )
    }
  }
 
}

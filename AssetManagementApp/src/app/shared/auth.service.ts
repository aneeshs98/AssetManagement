import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from './user';



// ahave to use 'ng g guard shared/auth' for creation


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient:HttpClient,private router:Router) { }


  getUserByPassword(user:User):Observable<any>{

    console.log("login")
    console.log("username : "+user.UserName);
    console.log("password : "+user.Userpassword);
   return this.httpClient.get(environment.apiUrl+"api/login/getuser/"+user.UserName+"/"+user.Userpassword);

  }
  getTokenByPassword(user:User):Observable<any>{

    console.log("Token generation")
    
   return this.httpClient.get(environment.apiUrl+"api/login/"+user.UserName+"/"+user.Userpassword);

  }

  public LogOut()
  {
    //localStorage.remove('username');
    localStorage.clear();
    sessionStorage.clear()
  }


}

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { ContactComponent } from './contact/contact.component';
import { EdituserComponent } from './users/edituser/edituser.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { UserComponent } from './users/user/user.component';
import { UsersComponent } from './users/users.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ManagerComponent } from './manager/manager.component';
import { AuthGuard } from './shared/auth.guard';
import { User } from './shared/user';

const routes: Routes = [
  {path: '',redirectTo:"/login",pathMatch:'full'},
  {path: 'admin',component: AdminComponent,canActivate:[AuthGuard],data:{role:'1'}},
  {path: 'manager',component:ManagerComponent,canActivate:[AuthGuard],data:{role:'2'} },
  {path: 'login',component: LoginComponent},
  {path: 'contact',component: ContactComponent},
  {path: 'users',component: UsersComponent},
  {path: 'user',component: UserComponent},
  {path: 'user/:empId',component: UserComponent},
  {path: 'userlist',component: UserListComponent,canActivate:[AuthGuard],data:{role:'1'}},
  {path: 'home',component: HomeComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

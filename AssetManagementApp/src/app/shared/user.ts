import { Role } from "./role";
export class User{
    UserId:number;
    UserName:string;
    Userpassword:string;
    RoleId:number;

    //object oriented
    role:Role;
    isActive:boolean;

}
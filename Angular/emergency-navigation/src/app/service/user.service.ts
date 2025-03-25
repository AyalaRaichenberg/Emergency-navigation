import { HttpClient } from "@angular/common/http";
import {  Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { User } from "../models/user.model";

@Injectable({
    providedIn:'root'
})
export class UserService{
    constructor(private _httpClient:HttpClient){}
    private baseUrl='https://localhost:7103/api/User'  
   isAuthenticeted$=new BehaviorSubject<boolean>(!!localStorage.getItem('appSession'));

   get isAuthenticeted():boolean{
    return this.isAuthenticeted$.getValue();
   }

    getUsersServer(): Observable<any> {     
        return this._httpClient.get(this.baseUrl);
      }
    addUserServer(user:User):Observable<any>{
        return this._httpClient.post<any>(this.baseUrl,user);
    }
    
    updateUserServer(user:User):Observable<any>{
      return this._httpClient.put<any>(this.baseUrl,user)
    }

    loginServer(loginModel:any):Observable<any>{
      return this._httpClient.post<any>('https://localhost:7103/api/controller',loginModel)     
    }
    checkEmail(email:string):Observable<any>{
      console.log("email:"+email);
      
      return this._httpClient.get<any>(`https://localhost:7103/api/User/${email}/email`);
    }
}
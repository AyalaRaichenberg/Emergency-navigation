import { HttpClient } from "@angular/common/http";
import {  Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { User } from "../models/user.model";

@Injectable({
    providedIn:'root'
})
export class FloorService{
    constructor(private _httpClient:HttpClient){}

    getFloorByIdServer(id:Number): Observable<any> {     
        return this._httpClient.get(`https://localhost:7103/api/Building/floors/${id}`);
      }
    getFloorById(id:Number): Observable<any> {     
        return this._httpClient.get(`https://localhost:7103/api/Floor/${id}`);
      }
}
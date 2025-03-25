import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Building } from "../models/building.model";



@Injectable({
  providedIn: 'root'
})
export class BuildingService {
  constructor(private _httpClient: HttpClient) { }
  private baseUrl = 'https://localhost:7103/api/Building'

  getBuildingsServer(): Observable<any> {
    return this._httpClient.get(this.baseUrl);
  }
  getBuildingByIdServer(id: number): Observable<any> {
    return this._httpClient.get(`${this.baseUrl}${id}`);
  }
  addBuildingServer(building: Building): Observable<Building> {
    return this._httpClient.post<Building>(this.baseUrl, building);
  }

  updateBuildingServer(building: Building): Observable<Building> {
    return this._httpClient.put<Building>(this.baseUrl, building)
  }

}
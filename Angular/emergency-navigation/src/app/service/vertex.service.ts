import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";



@Injectable({
  providedIn: 'root'
})
export class VertexService {
  constructor(private _httpClient: HttpClient) { }
  private baseUrl = 'https://localhost:7103/api/Vertex'

  getVertexServer(): Observable<any> {
    console.log("ghgh");

    return this._httpClient.get(this.baseUrl);
  }
  getVertexByFloorNumberServer(buildingId: number, floorNumber: number): Observable<any> {
    return this._httpClient.get(this.baseUrl);
  }

  getVertesListByFloor(floorId: number): Observable<any> {

    return this._httpClient.get(`${this.baseUrl}/floors/${floorId}/vertices`)

  }
  getVertesListByFloorAndBuilding(buildingId: number, floorNumber: number): Observable<any> {
    console.log(buildingId, "   ", floorNumber);

    return this._httpClient.post(`https://localhost:7103/api/Vertex/${buildingId}/${floorNumber}`, null)
  }
  sendAlert(alertData: any) {
    return this._httpClient.post("https://localhost:7103/api/Alert/send", alertData);
  }

}
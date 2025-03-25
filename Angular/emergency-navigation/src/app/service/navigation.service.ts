import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Building } from "../models/building.model";
import { Vertex } from "../models/vertex.model";
import { HttpHeaders } from '@angular/common/http';


@Injectable({
    providedIn: 'root'
})
export class NavigationService {
    constructor(private _httpClient: HttpClient) { }

    getNavigionFierServer(vertexId: number): Observable<any> {
        return this._httpClient.post('https://localhost:7103/api/controller/exit-building/no-stairs', vertexId,);
    }
    getNavigationSickServer(vertexId: number): Observable<any> {
        return this._httpClient.post('https://localhost:7103/api/controller/defibrillator', vertexId)
    }
    getNavigionTerroristInfiltrationServer(vertexId: number): Observable<any> {
        return this._httpClient.post('https://localhost:7103/api/controller/protected-room/no-stairs', vertexId);
    }
    getNavigionAlarmsServer(vertexId: number): Observable<any> {
        return this._httpClient.post('https://localhost:7103/api/controller/protected-room', vertexId);
    }
    getNavigionFloodServer(vertexId: number): Observable<any> {
        return this._httpClient.post('https://localhost:7103/api/controller/top-floor', vertexId);
    }
}

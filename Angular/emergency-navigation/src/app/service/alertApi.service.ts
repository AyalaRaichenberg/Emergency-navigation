// alert-api.service.ts - שירות שמנהל את ההתראות מפיקוד העורף
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AlertApiService {
  private alertUrl = 'https://www.oref.org.il/WarningMessages/alert/alerts.json';
  private buildingsUrl = 'https://yourserver.com/api/buildings';

  constructor(private http: HttpClient) {}

  getAlerts(): Observable<any> {
    return this.http.get<any>(this.alertUrl);
  }

  getAllBuildings(): Observable<any[]> {
    return this.http.get<any[]>(this.buildingsUrl);
  }

  mapAlertToCity(alert: any): string {
    if (alert && alert.data && alert.data.length > 0) {
      return alert.data[0].city || ''; // נניח שהעיר נמצאת במפתח "city"
    }
    return '';
  }

  filterBuildingsByCity(buildings: any[], city: string): any[] {
    return buildings.filter(building => building.city === city);
  }
   // ערה: אם תחליטי להפעיל את החיבור בזמן פריצת הודעה
  /*
  private hubConnection: signalR.HubConnection;
  private alertsSubject: any[] = [];  // לאחסן את ההתראות שמתקבלות
  public alerts$: Observable<any[]>;  // זרם לאחזור ההתראות

  constructor(private http: HttpClient) {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(this.signalRHubUrl)  // התחברות ל-Hub
      .build();

    // ערה: התחברות למערכת SignalR
    this.alerts$ = new Observable(observer => {
      this.hubConnection.on('ReceiveAlert', (alertMessage: string) => {
        this.alertsSubject.push(alertMessage);
        observer.next(this.alertsSubject);  // עדכון ההתראה למאזינים
      });

      // ערה: התחברות ל-SignalR Hub
      this.hubConnection.start()
        .catch(err => console.error('Error while starting connection: ' + err));
    });
  }
  */


    // שליחה של התראה לכל המחוברים לפי העיר
    sendAlertToCity(city: string, alertMessage: string): void {
      /*
      // ערה: שליחה של התראה ל-SignalR (לכל העיר)
      this.hubConnection.invoke('SendAlertToUsers', city, alertMessage)
        .catch(err => console.error('Error sending alert:', err));
      */
    }
    
}


import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AlertApiService } from '../service/alertApi.service'; // מיובא מתוך השירות

@Component({
  selector: 'app-alert-api',
  templateUrl: './alert-api.component.html',
  styleUrls: ['./alert-api.component.css']
})
export class AlertApiComponent implements OnInit {
  alerts: any; 
  buildings: any[] = []; // רשימת הבניינים

  constructor(private http: HttpClient, private alertApiService: AlertApiService) { }

  ngOnInit(): void {
    // שליפת ההתראות
    this.alertApiService.getAlerts().subscribe((data) => {
      this.alerts = data;
      console.log('Alerts:', this.alerts);
    }, error => {
      console.error('שגיאה בעת שליפת ההתראות', error);
    });

    // שליפת הבניינים
    this.alertApiService.getAllBuildings().subscribe((buildings) => {
      this.buildings = buildings;
      console.log('Buildings:', this.buildings);
    }, error => {
      console.error('שגיאה בעת שליפת הבניינים', error);
    });
  }

  // מיון הבניינים לפי העיר
  getBuildingsInCity(city: string): any[] {
    return this.alertApiService.filterBuildingsByCity(this.buildings, city);
  }

  // המרה של ההתראה לעיר
  mapAlertToCity(alert: any): string {
    if (alert && alert.data && alert.data.length > 0) {
      return alert.data[0].city || ''; 
    }
    return '';
  }

  // פעולה לשליחה של התראות למשתמשים בעיר
  sendAlertToCityBuildings(alert: any) {
    const city = this.mapAlertToCity(alert);
    const buildingsInCity = this.getBuildingsInCity(city);

    // שליחה של ההתראה לכל הבניינים בעיר
    buildingsInCity.forEach(building => {
      // כאן תוכל לקרוא לפונקציה ששולחת את ההתראה למשתמשים בבניין
      console.log(`Sending alert to building: ${building.name} in city: ${city}`);
      // לדוגמה, תוכל לקרוא לפונקציה במערכת שלך שתשלח את ההתראה
    });
  }


  // ngOnInit(): void {
  //   // ערה: הקוד להאזנה להתראות בזמן אמת
  //   /*
  //   this.alertApiService.alerts$.subscribe(alerts => {
  //     this.alerts = alerts;
  //     console.log('Received alerts:', this.alerts);
  //   });
  //   */
  // }

  // ngOnDestroy(): void {
  //   // ערה: סיום החיבור ל-SignalR במקרה של השמדת הקומפוננטה
  //   /*
  //   if (this.alertApiService) {
  //     this.alertApiService['hubConnection'].stop();
  //   }
  //   */
  // }
  
}
